import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ConfirmationService } from "primeng/api";
import {
  ItemRate,
  ItemRateRequest,
  Item
} from "../../../cores/models/item.model";
import { ItemRateService } from "../../../cores/services/item-rate.service";
import { ItemService } from "../../../cores/services/item.service";

@Component({
  selector: "app-price-list",
  templateUrl: "./price-list.component.html",
  styleUrls: ["./price-list.component.scss"]
})
export class PriceListComponent implements OnInit {
  dataSource: ItemRate[] = [];

  display = false;

  submitted = false;
  formControls: FormGroup;

  items: Item[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private rateService: ItemRateService,
    private itemService: ItemService,
    private confirmationService: ConfirmationService
  ) {}

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
    this.loadItems();

    this.formControls = this.formBuilder.group({
      id: [0],
      item: [null, Validators.required],
      rate: [null, Validators.required],
      tax: [10, Validators.required],
      discount: [0, Validators.required],
      priority: [1, Validators.required],
      isActive: [true, Validators.required],
      applyDate: [null, Validators.required]
    });
  }

  loadList() {
    this.rateService.getAll(0, 10).subscribe(data => {
      this.dataSource = data.dataSource ? data.dataSource : [];
    });
  }

  loadItems() {
    this.itemService.getAll(0, 100).subscribe(data => {
      if (data) {
        this.items = data.dataSource ? data.dataSource : [];
      }
    });
  }

  onShowAddDialog() {
    this.display = true;
  }

  onShowEditDialog(rate: ItemRate) {
    const item = this.items.filter(x => x.id === rate.itemId);
    this.controls.id.patchValue(rate.id);
    this.controls.item.patchValue(item[0]);
    this.controls.rate.patchValue(rate.rate);
    this.controls.tax.patchValue(rate.tax);
    this.controls.discount.patchValue(rate.discount);
    this.controls.priority.patchValue(rate.priority);
    this.controls.isActive.patchValue(rate.isActive);
    // this.controls.applyDate.patchValue(rate.applyDate);
    this.display = true;
  }

  onSaveClick() {
    this.submitted = true;
    this.formControls.markAsDirty();
    this.markAllControlDirty();

    if (this.formControls.valid) {
      const request = new ItemRateRequest();
      request.id = this.controls.id.value;
      request.itemId = this.controls.item.value.id;
      request.rate = this.controls.rate.value;
      request.tax = this.controls.tax.value;
      request.discount = this.controls.discount.value;
      request.priority = this.controls.priority.value;
      request.isActive = this.controls.isActive.value;
      request.applyDate = this.controls.applyDate.value;

      this.rateService.saveRate(request).subscribe(
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
        this.rateService.deleteRate(item.id).subscribe(data => {
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
