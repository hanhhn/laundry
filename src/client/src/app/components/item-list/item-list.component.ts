import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-item-list",
  templateUrl: "./item-list.component.html",
  styleUrls: ["./item-list.component.scss"]
})
export class ItemListComponent implements OnInit {
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

  constructor() {}

  ngOnInit() {}
}
