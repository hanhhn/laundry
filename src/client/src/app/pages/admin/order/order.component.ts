import { Component, OnInit } from "@angular/core";
import { Order, OrderFilter } from "src/app/cores/models/orders.model";
import { OrdersService } from "src/app/cores/services/orders.service";
import { PagedList } from "src/app/cores/models/paged.model";

@Component({
  selector: "app-order",
  templateUrl: "./order.component.html",
  styleUrls: ["./order.component.scss"]
})
export class OrderComponent implements OnInit {
  dataSource: Order[];
  pageIndex: number;
  pageSize: number;
  totalRecord: number;
  totalPage: number;

  filter: OrderFilter;

  constructor(private orderService: OrdersService) {
    this.pageIndex = 0;
    this.pageSize = 10;
  }

  ngOnInit() {
    this.orderService
      .getAll(this.filter, this.pageIndex, this.pageSize)
      .subscribe(data => {
        if (data) {
          this.dataSource = data.dataSource;
          this.totalPage = data.totalPage;
          this.totalRecord = data.totalRecord;
        }
      });
  }
}
