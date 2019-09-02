import { Component, OnInit, Input } from "@angular/core";

@Component({
  selector: "app-item",
  templateUrl: "./item.component.html",
  styleUrls: ["./item.component.scss"]
})
export class ItemComponent {
  @Input()
  itemUrl: string;

  @Input()
  itemName: string;

  @Input()
  itemRate: string;
}
