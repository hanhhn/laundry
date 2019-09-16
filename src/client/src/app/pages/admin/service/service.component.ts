import { Component, OnInit } from "@angular/core";
import { ItemService } from "../../../cores/services/item.service";
import { Item, ItemRequest } from "../../../cores/models/item.model";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ImageService } from "../../../cores/services/image.service";
import { ConfirmationService } from "primeng/api";
import { KeyValue } from "../../../cores/models/object.model";
import { MethodService } from "src/app/cores/services/method.service";
import { Method } from "src/app/cores/models/method.model";

@Component({
  selector: "app-service",
  templateUrl: "./service.component.html",
  styleUrls: ["./service.component.scss"]
})
export class ServiceComponent implements OnInit {
  dataSource: Item[];
  itemTypes: KeyValue[];
  comboMethods: Method[];

  display: boolean;
  submitted: boolean;
  formControls: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private itemService: ItemService,
    private imageService: ImageService,
    private methodService: MethodService,
    private confirmationService: ConfirmationService
  ) {
    this.dataSource = [];
    this.itemTypes = [];
    this.display = false;
    this.submitted = false;
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
    this.loadItemList();
    this.loadItemType();
    this.loadComboMethod();

    this.formControls = this.formBuilder.group({
      id: [0],
      type: [null, Validators.required],
      image: [null, Validators.required],
      name: [null, Validators.required],
      combo: [null, Validators.required],
      description: [null, Validators.required],
      sortOrder: [1, Validators.required],
      highlight: [false]
    });
  }

  loadItemList() {
    this.itemService.getAll(0, 100).subscribe(data => {
      this.dataSource = data.dataSource ? data.dataSource : [];
    });
  }

  loadItemType() {
    this.itemTypes = this.itemService.getItemTypes();
  }

  loadComboMethod() {
    this.methodService.getCombo(0, 100).subscribe(data => {
      this.comboMethods = data ? data.dataSource : [];
    });
  }

  onShowAddDialog() {
    this.display = true;
    this.formControls.reset();
    this.controls.id.patchValue(0);
    this.controls.sortOrder.patchValue(1);
    this.controls.highlight.patchValue(false);
  }

  onShowEditDialog(item: Item) {
    const type = this.itemTypes.find(x => x.key === item.type);
    const combo = this.comboMethods.find(x => x.id === item.comboId);
    this.controls.id.patchValue(item.id);
    this.controls.type.patchValue(type);
    this.controls.image.patchValue(item.image);
    this.controls.name.patchValue(item.name);
    this.controls.combo.patchValue(combo);
    this.controls.description.patchValue(item.description);
    this.controls.sortOrder.patchValue(item.sortOrder);
    this.controls.highlight.patchValue(item.highlight);
    this.display = true;
  }

  onSaveItemClick() {
    this.submitted = true;
    this.formControls.markAsDirty();
    this.markAllControlDirty();

    if (this.formControls.valid) {
      const request = new ItemRequest();
      request.id = this.controls.id.value;
      request.name = this.controls.name.value;
      request.type = this.controls.type.value.key;
      request.comboId = this.controls.combo.value.id;
      request.image = this.controls.image.value;
      request.description = this.controls.description.value;
      request.sortOrder = this.controls.sortOrder.value;
      request.highlight = this.controls.highlight.value;

      this.itemService.saveItem(request).subscribe(
        data => {
          if (data) {
            alert("Lưu dữ liệu thành công");
          } else {
            alert("Xẩy ra lỗi xin vui lòng thử lại sau.");
          }

          this.display = false;
          this.loadItemList();
        },
        err => {
          alert(err);
        }
      );
    }
  }

  onDeleteItemClick(item) {
    this.confirmationService.confirm({
      message: "Bạn chắc chắn muốn xóa '" + item.name + "'",
      acceptLabel: "Xác nhận",
      rejectLabel: "Hủy",
      accept: () => {
        this.itemService.deleteItem(item.id).subscribe(data => {
          if (data) {
            alert("Xóa dữ liệu thành công");
          } else {
            alert("Xẩy ra lỗi xin vui lòng thử lại sau.");
          }

          this.loadItemList();
        });
      },
      reject: () => {}
    });
  }

  onImageSelected(event: any) {
    if (event.files && event.files.length > 0) {
      const file = event.files[0];

      // file size max 2mb
      if (file && file.size < 2097152) {
        this.imageService.uploadToImgur(
          file,
          respon => {
            if (respon && respon.status === 200) {
              this.controls.image.setValue(respon.data.link);
            }
          },
          error => {
            alert("Xẩy ra lỗi xin vui lòng thử lại sau.");
          }
        );
      }
    }
  }
}
