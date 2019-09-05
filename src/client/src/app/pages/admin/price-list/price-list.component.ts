import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ConfirmationService } from "primeng/api";
import { Item } from "../../../cores/models/item.model";
import { ItemService } from "../../../cores/services/item.service";
import { Price, PriceRequest } from "src/app/cores/models/price.model";
import { PriceService } from "src/app/cores/services/price.service";
import { KeyValue } from "src/app/cores/models/object.model";
import { MethodService } from "src/app/cores/services/method.service";
import { map } from "rxjs/operators";
import { fromDate } from "../../../cores/helpers/utils.helper";
@Component({
  selector: "app-price-list",
  templateUrl: "./price-list.component.html",
  styleUrls: ["./price-list.component.scss"]
})
export class PriceListComponent implements OnInit {
  display: boolean;
  submitted: boolean;
  formControls: FormGroup;

  items: KeyValue[];
  itemCodes: KeyValue[];
  dataSource: Price[];

  constructor(
    private formBuilder: FormBuilder,
    private priceService: PriceService,
    private itemService: ItemService,
    private methodService: MethodService,
    private confirmationService: ConfirmationService
  ) {
    this.display = false;
    this.submitted = false;
    this.items = [];
    this.dataSource = [];
  }

  get controls() {
    return this.formControls.controls;
  }

  private markAllControlDirty(): void {
    // tslint:disable-next-line:forin
    for (const i in this.formControls.controls) {
      this.formControls.controls[i].markAsDirty();
    }
  }

  ngOnInit() {
    this.loadList();
    this.itemCodes = this.itemService.getItemCodes();

    this.formControls = this.formBuilder.group({
      id: [0],
      item: [null, Validators.required],
      itemCode: [null, Validators.required],
      rate: [null, Validators.required],
      tax: [10, Validators.required],
      discount: [0, Validators.required],
      priority: [1, Validators.required],
      isActive: [true, Validators.required],
      applyDate: [null, Validators.required],
      expireDate: [null, Validators.required]
    });
  }

  loadList() {
    this.priceService.getAll(0, 100).subscribe(data => {
      const result = data.dataSource ? data.dataSource : [];
      this.dataSource = result.map(item => {
        item.applyDate = fromDate(item.applyDate.toString());
        item.expireDate = fromDate(item.expireDate.toString());
        return item;
      });
    });
  }

  loadItems(code: string) {
    switch (code) {
      case "Method":
        this.loadMethod();
        break;

      case "Item":
        this.loadItem();
        break;
    }
  }

  loadMethod() {
    this.methodService
      .getAll(0, 100)
      .pipe(
        map(data => {
          return data
            ? data.dataSource.map(x => new KeyValue(x.id, x.name))
            : [];
        })
      )
      .subscribe(data => {
        this.items = data;
      });
  }

  loadItem() {
    this.itemService
      .getAll(0, 100)
      .pipe(
        map(data => {
          return data
            ? data.dataSource.map(x => new KeyValue(x.id, x.name))
            : [];
        })
      )
      .subscribe(data => {
        this.items = data;
      });
  }

  onItemCodeChanged(e) {
    if (e && e.value.key) {
      this.loadItems(e.value.key);
    }
  }

  onShowAddDialog() {
    this.display = true;
    this.formControls.reset();
    this.controls.id.patchValue(0);
    this.controls.rate.patchValue(0);
    this.controls.tax.patchValue(10);
    this.controls.discount.patchValue(0);
    this.controls.priority.patchValue(1);
    this.controls.isActive.patchValue(true);
  }

  onShowEditDialog(rate: Price) {
    const itemCode = this.itemCodes.filter(x => x.key === rate.itemCode);
    this.loadItems(rate.itemCode);

    const item = this.items.filter(x => x.key === rate.itemId);
    this.controls.id.patchValue(rate.id);
    this.controls.itemCode.patchValue(itemCode[0]);
    this.controls.item.patchValue(item[0]);
    this.controls.rate.patchValue(rate.rate);
    this.controls.tax.patchValue(rate.tax);
    this.controls.discount.patchValue(rate.discount);
    this.controls.priority.patchValue(rate.priority);
    this.controls.isActive.patchValue(rate.isActive);
    this.controls.applyDate.patchValue(rate.applyDate);
    this.controls.expireDate.patchValue(rate.expireDate);
    this.display = true;
  }

  onSaveClick() {
    this.submitted = true;
    this.formControls.markAsDirty();
    this.markAllControlDirty();

    if (this.formControls.valid) {
      const request = new PriceRequest();
      request.id = this.controls.id.value;
      request.itemId = this.controls.item.value.key;
      request.itemCode = this.controls.itemCode.value.key;
      request.rate = this.controls.rate.value;
      request.tax = this.controls.tax.value;
      request.discount = this.controls.discount.value;
      request.priority = this.controls.priority.value;
      request.isActive = this.controls.isActive.value;
      request.applyDate = this.controls.applyDate.value;
      request.expireDate = this.controls.expireDate.value;

      this.priceService.saveRate(request).subscribe(
        data => {
          if (data) {
            alert("Lưu dữ liệu thành công.");
          } else {
            alert("Xẩy ra lỗi xin vui lòng thử lại sau.");
          }

          this.display = false;
          this.loadList();
        },
        err => {
          alert(err);
        }
      );
    }
  }

  onDeleteClick(item) {
    this.confirmationService.confirm({
      message: "Bạn chắc chắn muốn xóa đơn giá",
      acceptLabel: "Xác nhận",
      rejectLabel: "Hủy",
      accept: () => {
        this.priceService.deleteRate(item.id).subscribe(data => {
          if (data) {
            alert("Xóa dữ liệu thành công");
          } else {
            alert("Xẩy ra lỗi xin vui lòng thử lại sau.");
          }

          this.loadList();
        });
      }
    });
  }
}
