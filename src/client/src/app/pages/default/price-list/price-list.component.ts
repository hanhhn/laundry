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
