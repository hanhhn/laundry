import { Component, OnInit } from "@angular/core";
import {
  Order,
  OrderFilter,
  OrderDetail
} from "src/app/cores/models/orders.model";
import { OrdersService } from "src/app/cores/services/orders.service";
import { PagedList } from "src/app/cores/models/paged.model";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";

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

  submitted: boolean;
  display: boolean;
  order: Order;
  formControls: FormGroup;

  get controls() {
    return this.formControls.controls;
  }

  constructor(
    private orderService: OrdersService,
    private formBuilder: FormBuilder
  ) {
    this.pageIndex = 0;
    this.pageSize = 10;
    this.submitted = false;
    this.display = false;
  }

  ngOnInit() {
    this.formControls = this.formBuilder.group({});
    this.loadDataSource();
  }

  onPaging(e) {
    this.pageIndex = e.page;
    this.pageSize = e.rows;
    this.totalPage = e.pageCount;

    this.loadDataSource();
  }

  loadDataSource() {
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

  getService(orderDetails: OrderDetail[]): string {
    return orderDetails.find(x => x.type === "Clean").methodName;
  }

  onPrintGoodsReceipt(id) {
    this.orderService.get(id).subscribe(data => {
      if (data) {
        this.order = data;
      }
    });
  }

  onShowOrderInfo(id) {
    this.display = true;
    this.submitted = false;
    this.orderService.get(id).subscribe(data => {
      if (data) {
        this.order = data;
      }
    });
  }
}
