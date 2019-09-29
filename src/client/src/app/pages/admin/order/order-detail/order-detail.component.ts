import { Component, OnInit } from "@angular/core";
import {
  Order,
  OrderFilter,
  OrderDetail,
  OrderDetailRequest,
  Detail
} from "src/app/cores/models/orders.model";
import { OrdersService } from "src/app/cores/services/orders.service";
import { FormGroup, FormBuilder, Validators, FormArray } from "@angular/forms";
import { ActivatedRoute } from "@angular/router";
import { Method } from "src/app/cores/models/method.model";
import { MethodService } from "src/app/cores/services/method.service";
import { forkJoin } from "rxjs";
import { BillingService } from "src/app/cores/services/billing.service";
import { Bill } from "src/app/cores/models/billing.model";

const METHOD = {
  CLEAN: "Clean",
  DELIVERY: "Delivery",
  OTHER: "Other"
};

@Component({
  selector: "app-order-detail",
  templateUrl: "./order-detail.component.html",
  styleUrls: ["./order-detail.component.scss"]
})
export class OrderDetailComponent implements OnInit {
  order: Order;

  id: string;

  serviceFormGroup: FormGroup;

  methods: Method[];

  bill: Bill;

  get getWayClean() {
    return this.methods.filter(x => x.type === METHOD.CLEAN);
  }

  get getOptions() {
    return this.methods.filter(x => x.type === METHOD.OTHER);
  }

  get serviceControls() {
    return this.serviceFormGroup.controls;
  }

  get optionArray(): FormArray {
    return this.serviceFormGroup.get("options") as FormArray;
  }

  get optionControls() {
    return this.optionArray.controls;
  }

  get methodGroup(): FormGroup {
    return this.serviceFormGroup.get("method") as FormGroup;
  }

  get methodControls() {
    return this.methodGroup.controls;
  }

  constructor(
    private orderService: OrdersService,
    private methodService: MethodService,
    private billingService: BillingService,
    private formBuilder: FormBuilder,
    route: ActivatedRoute
  ) {
    route.params.subscribe(param => {
      if (param) {
        this.id = param.id;
      }

      this.serviceFormGroup = this.formBuilder.group({
        method: this.formBuilder.group({
          clean: [null, Validators.required],
          qty: [null, Validators.required]
        }),
        options: this.formBuilder.array([]),
        note: [null]
      });
    });
  }

  ngOnInit() {
    if (this.id) {
      this.loadDataSource(this.id);
    }
  }

  getUnit(id) {
    return this.methods.find(x => x.id === id).unit;
  }

  loadDataSource(id) {
    forkJoin([
      this.orderService.get(id),
      this.methodService.getApplyMethod(0, 100)
    ]).subscribe(([order, option]) => {
      this.order = order;
      this.methods = option ? option.dataSource : [];

      const m = this.order.orderDetails.find(x => x.type === "Clean");
      const c = this.methods.find(x => x.id === m.methodId);
      this.methodControls.clean.patchValue(c);
      this.methodControls.qty.patchValue(m ? m.qty : null);

      this.getOptions.map((value, index) => {
        const o = this.order.orderDetails.find(x => x.methodId === value.id);

        this.optionControls.push(
          this.formBuilder.group({
            option: this.formBuilder.control(o ? true : false),
            qty: [{ value: o ? o.qty : 0, disabled: true }]
          })
        );
      });

      this.loadBilling();
    });
  }

  loadBilling() {
    if (this.order.billId && this.order.billId > 0) {
      this.billingService.get(this.order.billId).subscribe(
        data => {
          if (data) {
            this.bill = data;
          }
        },
        err => {
          alert(err);
        }
      );
    }
  }

  onQtyChanged(e) {
    if (e && e.target) {
      this.optionControls.map((group, index) => {
        if (group.get("option").value) {
          group.get("qty").patchValue(e.target.value);
        }
      });
    }
  }

  onOptionChanged(e, i) {
    if (e && e.target) {
      if (e.target.checked) {
        this.optionControls[i]
          .get("qty")
          .patchValue(this.methodControls.qty.value);
      } else {
        this.optionControls[i].get("qty").patchValue(0);
      }
    }
  }

  enabledInputClick(e) {
    if (e) {
    }
  }

  onUpdateOrderClicked(e) {
    this.serviceFormGroup.markAllAsTouched();

    if (this.serviceFormGroup.valid) {
      const request = new OrderDetailRequest();
      request.orderId = this.id;
      request.note = this.serviceControls.note.value;

      const clean = new Detail();
      clean.methodId = this.methodControls.clean.value.id;
      clean.qty = this.methodControls.qty.value * 1;
      request.details.push(clean);

      this.optionControls.map((group, index) => {
        if (group.get("option").value) {
          const option = new Detail();
          option.methodId = this.getOptions[index].id;
          option.qty = group.get("qty").value * 1;
          request.details.push(option);
        }
      });

      this.orderService.updateOrder(request).subscribe(data => {
        if (data) {
          alert("Cập nhật thông tin đơn hàng thành công");
        }
      });
    }
  }

  onPublishClicked(e) {
    e.preventDefault();

    this.billingService.publish(this.id).subscribe(
      data => {
        if (data) {
          this.bill = data;
        }
      },
      err => {
        alert("Xảy ra lỗi");
      }
    );
  }
}
