import { Component, OnInit } from "@angular/core";
import {
  Order,
  OrderFilter,
  OrderDetail
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

  get optionControls(): FormArray {
    return this.serviceFormGroup.get("options") as FormArray;
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
        clean: [null, Validators.required],
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

  loadDataSource(id) {
    forkJoin([
      this.orderService.get(id),
      this.methodService.getApplyMethod(0, 100)
    ]).subscribe(([order, option]) => {
      this.order = order;
      this.methods = option ? option.dataSource : [];
      this.serviceControls.clean.patchValue(
        this.order.orderDetails.find(x => x.type === "Clean").id
      );
      this.getOptions.map((value, index) => {
        const checked = this.order.orderDetails.find(
          x => x.methodId === value.id
        );
        this.optionControls.controls.push(
          this.formBuilder.control(checked ? true : false)
        );
      });

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
    });
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
