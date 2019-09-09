import { Component, OnInit, ViewChild } from "@angular/core";
import { ItemService } from "../../../cores/services/item.service";
import { Item } from "../../../cores/models/item.model";
import { SniperService } from "../../../cores/services/sniper.service";
import { Observable, forkJoin } from "rxjs";

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

  combo: Item[] = [];

  constructor(
    private sniper: SniperService,
    private itemService: ItemService
  ) {}

  ngOnInit() {
    this.loadService();
  }

  loadService() {
    this.sniper.showSniper();
    forkJoin([
      this.itemService.getLaundry(0, 3),
      this.itemService.getDryClean(0, 100)
    ]).subscribe(
      ([laundry, dryClean]) => {
        this.combo = laundry ? laundry.dataSource : [];
        this.items = dryClean ? dryClean.dataSource : [];
        this.sniper.hideSniper();
      },
      err => {
        this.sniper.hideSniper();
      }
    );
  }
}
