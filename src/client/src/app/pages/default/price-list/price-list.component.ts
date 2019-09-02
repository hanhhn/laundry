import { Component, OnInit, ViewChild } from "@angular/core";
import { ItemService } from "../../../cores/services/item.service";
import { Item } from "../../../cores/models/item.model";

@Component({
  selector: "app-price-list",
  templateUrl: "./price-list.component.html",
  styleUrls: ["./price-list.component.scss"]
})
export class PriceListComponent implements OnInit {
  itemNormal = [
    {
      title: "item 1",
      description: "asdasd sfdf",
      rate: "10k"
    },
    {
      title: "item 2",
      description: "asda asd",
      rate: "20k"
    },
    {
      title: "item 3",
      description: "123asd ad",
      rate: "40k"
    }
  ];

  items: Item[] = [];

  constructor(private itemService: ItemService) {}

  ngOnInit() {
    this.itemService.getAll(0, 100).subscribe(data => {
      this.items = data ? data.dataSource : [];
    });
  }
}
