import { Component, OnInit, ViewChild } from "@angular/core";

@Component({
  selector: "app-price-list",
  templateUrl: "./price-list.component.html",
  styleUrls: ["./price-list.component.scss"]
})
export class PriceListComponent implements OnInit {
  nacyUrl = "../../../../assets/nacy.jpg";

  items = [
    {
      imageUrl: this.nacyUrl,
      name: "Áo/Quần bình thường",
      rate: "12"
    },
    {
      imageUrl: this.nacyUrl,
      name: "Vest",
      rate: "12"
    },
    {
      imageUrl: this.nacyUrl,
      name: "Áo dài",
      rate: "12"
    },
    {
      imageUrl: this.nacyUrl,
      name: "Ba lô/Túi Xách ",
      rate: "12"
    },
    {
      imageUrl: this.nacyUrl,
      name: "Thú nhồi bông",
      rate: "12"
    },
    {
      imageUrl: this.nacyUrl,
      name: "Chất liệu khác ",
      rate: "12"
    }
  ];

  ngOnInit() {}
}
