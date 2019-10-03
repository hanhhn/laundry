import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ConfirmationService } from "primeng/api";
import { Method, MethodRequest } from "../../../../cores/models/method.model";
import { MethodService } from "../../../../cores/services/method.service";
import { KeyValue } from "src/app/cores/models/object.model";
import { forkJoin } from "rxjs";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: "app-method-detail",
  templateUrl: "./method-detail.component.html",
  styleUrls: ["./method-detail.component.scss"]
})
export class MethodDetailComponent implements OnInit {
  submitted: boolean;
  methodTypes: KeyValue[];
  method: Method;
  id: number;

  formControls: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private methodService: MethodService,
    private router: Router,
    route: ActivatedRoute
  ) {
    this.method = null;
    this.methodTypes = [];
    this.submitted = false;
    route.params.subscribe(param => {
      if (param) {
        this.id = param.id ? param.id : 0;
      }
    });
  }

  get controls() {
    return this.formControls.controls;
  }

  ngOnInit() {
    this.loadDataSource();
  }

  loadDataSource() {
    forkJoin([
      this.methodService.getMethodTypes(),
      this.methodService.get(this.id)
    ]).subscribe(([methodType, method]) => {
      this.methodTypes = methodType;
      this.method = method;
      this.initForm();
    });
  }

  initForm() {
    this.formControls = this.formBuilder.group({
      id: [0],
      type: [null, Validators.required],
      name: [null, Validators.required],
      unit: [null, Validators.required],
      description: [null, Validators.required],
      sortOrder: [1, Validators.required],
      enableDiscount: [false]
    });

    if (this.method) {
      this.onShowEdit(this.method);
    } else {
      this.onShowAdd();
    }
  }

  onShowAdd() {
    this.submitted = false;
    this.formControls.reset();
    this.formControls.markAsUntouched();
    this.controls.id.patchValue(0);
    this.controls.sortOrder.patchValue(1);
    this.controls.enableDiscount.patchValue(false);
  }

  onShowEdit(method: Method) {
    const type = this.methodTypes.find(x => x.key === method.type);
    this.controls.id.patchValue(method.id);
    this.controls.type.patchValue(type);
    this.controls.unit.patchValue(method.unit);
    this.controls.name.patchValue(method.name);
    this.controls.description.patchValue(method.description);
    this.controls.sortOrder.patchValue(method.sortOrder);
    this.controls.enableDiscount.patchValue(method.enableDiscount);
    this.submitted = false;
  }

  onSaveClick() {
    this.submitted = true;
    this.formControls.markAllAsTouched();

    if (this.formControls.valid) {
      const request = new MethodRequest();
      request.id = this.controls.id.value;
      request.name = this.controls.name.value;
      request.description = this.controls.description.value;
      request.sortOrder = this.controls.sortOrder.value;
      request.enableDiscount = this.controls.enableDiscount.value;
      request.type = this.controls.type.value.key;
      request.unit = this.controls.unit.value;

      this.methodService.save(request).subscribe(
        data => {
          if (data) {
            alert("Lưu dữ liệu thành công.");
            this.router.navigate(["/admin/method"]);
          } else {
            alert("Xẩy ra lỗi xin vui lòng thử lại sau.");
          }
        },
        err => {
          alert(err);
        }
      );
    }
  }
}
