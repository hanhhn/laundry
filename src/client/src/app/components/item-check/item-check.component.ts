import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { MAT_CHECKBOX_CLICK_ACTION } from "@angular/material";

@Component({
  selector: "app-item",
  templateUrl: "./item-check.component.html",
  styleUrls: ["./item-check.component.scss"],
  providers: [{ provide: MAT_CHECKBOX_CLICK_ACTION, useValue: "noop" }]
})
export class ItemCheckComponent implements OnInit {
  @Input()
  id: string;

  @Input()
  itemUrl: string;

  @Input()
  itemName: string;

  @Input()
  itemRate: string;

  @Input()
  checked: boolean;

  @Output()
  itemChecked = new EventEmitter<boolean>();

  ngOnInit() {
    if (!this.checked) {
      this.checked = false;
    }
  }

  onChecked() {
    this.checked = !this.checked;
    this.itemChecked.emit(this.checked);
  }
}
