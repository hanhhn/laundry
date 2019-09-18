import { Component, OnInit, Input } from "@angular/core";

@Component({
  selector: "app-price-item",
  templateUrl: "./price-item.component.html",
  styleUrls: ["./price-item.component.scss"]
})
export class PriceItemComponent {
  @Input()
  image: string;

  @Input()
  title: string;

  @Input()
  description: string;

  @Input()
  rate: number;
}
