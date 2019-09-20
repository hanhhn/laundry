import { Component, OnInit } from "@angular/core";
import { SniperService } from "src/app/cores/services/sniper.service";
import {
  animate,
  state,
  style,
  transition,
  trigger
} from "@angular/animations";
import { ActivatedRoute } from "@angular/router";
import { TrackingService } from "src/app/cores/services/trackings.service";
import { OrderHistory } from "src/app/cores/models/orders.model";

@Component({
  selector: "app-tracking",
  templateUrl: "./tracking.component.html",
  styleUrls: ["./tracking.component.scss"],
  animations: [
    trigger("detailExpand", [
      state("collapsed", style({ height: "0px", minHeight: "0" })),
      state("expanded", style({ height: "*" })),
      transition(
        "expanded <=> collapsed",
        animate("225ms cubic-bezier(0.4, 0.0, 0.2, 1)")
      )
    ])
  ]
})
export class TrackingComponent implements OnInit {
  phone: string;
  code: string;

  dataSource: OrderHistory;

  constructor(
    private sniper: SniperService,
    route: ActivatedRoute,
    private trackingService: TrackingService
  ) {
    route.queryParams.subscribe(param => {
      if (param) {
        this.phone = param.phone;
        this.code = param.code;
      }
    });
  }

  ngOnInit() {
    this.getDataSource();
  }

  getDataSource() {
    if (this.phone && this.code) {
      this.sniper.showSniper();
      this.trackingService.order(this.phone, this.code).subscribe(data => {
        this.dataSource = data;
      });
    }
  }
}
