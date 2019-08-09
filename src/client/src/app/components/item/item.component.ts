import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-item",
  templateUrl: "./item.component.html",
  styleUrls: ["./item.component.scss"]
})
export class ItemComponent implements OnInit {
  imgUrl = "https://www.heramo.com/assets/images/prices/dry_cleaning/Heramo-bang-gia-giat-hap-quan-jeans.jpg";

  constructor() {}

  ngOnInit() {}
}
