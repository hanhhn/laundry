import { Component, OnInit, Input, OnChanges } from "@angular/core";
import { Reason } from "src/app/cores/models/setting.model";

@Component({
  selector: "app-selection",
  templateUrl: "./selection.component.html",
  styleUrls: ["./selection.component.scss"]
})
export class SelectionComponent implements OnChanges {
  @Input()
  dataSource: Reason;

  left: string[];

  right: string[];

  constructor() {
    this.left = [];
    this.right = [];
  }

  ngOnChanges() {
    if (this.dataSource && this.dataSource.reasons) {
      const reasons = this.dataSource.reasons
        .reverse()
        .slice(0, 6)
        .reverse();

      reasons.forEach((value, index) => {
        if (index > 2 ) {
          this.right.push(value);
        } else {
          this.left.push(value);
        }
      });
    }
  }
}
