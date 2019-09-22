import { Component, OnInit } from "@angular/core";
import { SniperService } from "src/app/cores/services/sniper.service";
import { ActivatedRoute } from "@angular/router";
import { TrackingService } from "src/app/cores/services/trackings.service";
import { OrderHistory } from "src/app/cores/models/orders.model";
import { Method } from "src/app/cores/models/method.model";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";

@Component({
  selector: "app-tracking",
  templateUrl: "./tracking.component.html",
  styleUrls: ["./tracking.component.scss"]
})
export class TrackingComponent implements OnInit {
  phone: string;
  code: string;

  order: OrderHistory;

  clean: Method;

  options: Method[];

  formControls: FormGroup;

  get controls() {
    return this.formControls.controls;
  }

  constructor(
    private sniper: SniperService,
    route: ActivatedRoute,
    private trackingService: TrackingService,
    private formBuilder: FormBuilder
  ) {
    route.queryParams.subscribe(param => {
      if (param) {
        this.phone = param.phone;
        this.code = param.code;
      }
    });
  }

  ngOnInit() {
    this.intiFormControls();
    this.controls.phone.patchValue(this.phone);
    this.controls.code.patchValue(this.code);

    if (this.formControls.valid) {
      this.getDataSource(this.controls.phone.value, this.controls.code.value);
    }
  }

  intiFormControls() {
    this.formControls = this.formBuilder.group({
      phone: [null, Validators.required],
      code: [null, Validators.required]
    });
  }

  onSearchClicked(e) {
    if (this.formControls.valid) {
      this.getDataSource(this.controls.phone.value, this.controls.code.value);
    }
  }

  getDataSource(phone: string, code: string) {
    if (phone && code) {
      this.sniper.showSniper();
      this.trackingService.order(phone, code).subscribe(
        data => {
          this.order = data;
          if (this.order) {
            this.clean = this.order.services.find(x => x.type === "Clean");
            this.options = this.order.services.filter(x => x.type !== "Clean" && x.type !== "Delivery");
          }

          this.sniper.hideSniper();
        },
        err => {
          this.order = null;
          this.sniper.hideSniper();
        }
      );
    }
  }
}
