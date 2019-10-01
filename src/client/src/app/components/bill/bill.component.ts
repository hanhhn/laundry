import { Component, OnInit, Input } from "@angular/core";
import { Bill } from "src/app/cores/models/billing.model";

@Component({
  selector: "app-bill",
  templateUrl: "./bill.component.html",
  styleUrls: ["./bill.component.scss"]
})
export class BillComponent {
  @Input()
  bill: Bill;

  onPrint() {
    window.print();
  }
}
