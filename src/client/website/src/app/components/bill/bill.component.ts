import { Component, OnInit, Input } from "@angular/core";
import { Bill } from "src/app/cores/models/billing.model";
import * as print from "print-js";

@Component({
  selector: "app-bill",
  templateUrl: "./bill.component.html",
  styleUrls: ["./bill.component.scss"]
})
export class BillComponent {
  @Input()
  bill: Bill;

  onPrint() {
    const html = document.getElementById("printArea").innerHTML;
    print("printArea", "html");
  }
}
