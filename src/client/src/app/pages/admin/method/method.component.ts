import { Component, OnInit } from "@angular/core";
import { Method, MethodRequest } from "../../../cores/models/method.model";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { MethodService } from "../../../cores/services/method.service";
import { ConfirmationService } from "primeng/api";
import { KeyValue } from "../../../cores/models/object.model";

@Component({
  selector: "app-method",
  templateUrl: "./method.component.html",
  styleUrls: ["./method.component.scss"]
})
export class MethodComponent implements OnInit {
  display: boolean;
  submitted: boolean;
  methodTypes: KeyValue[];
  dataSource: Method[];

  formControls: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private methodService: MethodService,
    private confirmationService: ConfirmationService
  ) {
    this.dataSource = [];
    this.methodTypes = [];
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
    this.loadList();
    this.loadMethodType();

    this.formControls = this.formBuilder.group({
      id: [0],
      type: [null, Validators.required],
      name: [null, Validators.required],
      description: [null, Validators.required],
      sortOrder: [1, Validators.required],
      enableDiscount: [false]
    });
  }

  loadList() {
    this.methodService.getAll(0, 100).subscribe(data => {
      this.dataSource = data.dataSource ? data.dataSource : [];
    });
  }

  loadMethodType() {
    this.methodTypes = this.methodService.getMethodTypes();
  }

  onShowAddDialog() {
    this.display = true;
    this.submitted = false;
    this.formControls.reset();
    this.controls.id.patchValue(0);
    this.controls.sortOrder.patchValue(1);
    this.controls.enableDiscount.patchValue(false);
  }

  onShowEditDialog(method: Method) {
    const type = this.methodTypes.filter(x => x.key === method.type);
    this.controls.id.patchValue(method.id);
    this.controls.type.patchValue(type[0]);
    this.controls.name.patchValue(method.name);
    this.controls.description.patchValue(method.description);
    this.controls.sortOrder.patchValue(method.sortOrder);
    this.controls.enableDiscount.patchValue(method.enableDiscount);
    this.display = true;
    this.submitted = false;
  }

  onSaveClick() {
    this.submitted = true;
    this.formControls.markAsDirty();
    this.markAllControlDirty();

    if (this.formControls.valid) {
      const request = new MethodRequest();
      request.id = this.controls.id.value;
      request.name = this.controls.name.value;
      request.description = this.controls.description.value;
      request.sortOrder = this.controls.sortOrder.value;
      request.enableDiscount = this.controls.enableDiscount.value;
      request.type = this.controls.type.value.key;

      this.methodService.save(request).subscribe(
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
      message: "Bạn chắc chắn muốn xóa dữ liệu",
      acceptLabel: "Xác nhận",
      rejectLabel: "Hủy",
      accept: () => {
        this.methodService.delete(item.id).subscribe(data => {
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
