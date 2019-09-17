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
  prices: Item[] = [];

  combo: Item[] = [];

  laundry: Item[] = [];

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
      this.itemService.getPriceList(0, 3),
      this.itemService.getCombo(0, 3),
      this.itemService.getLaundry(0, 100)
    ]).subscribe(
      ([prices, combo, laundry]) => {
        this.prices = prices ? prices.dataSource : [];
        this.combo = combo ? combo.dataSource : [];
        this.laundry = laundry ? laundry.dataSource : [];

        this.sniper.hideSniper();
      },
      err => {
        this.sniper.hideSniper();
      }
    );
  }
}
