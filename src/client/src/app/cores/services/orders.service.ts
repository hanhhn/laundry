import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { toQueryString } from "../helpers/utils.helper";
import { PagedList } from "../models/paged.model";
import {
  OrderRequest,
  Order,
  OrderFilter,
  OrderDetailRequest
} from "../models/orders.model";

@Injectable()
export class OrdersService {
  constructor(private httpService: HttpService) {}

  saveOrder(order: OrderRequest): Observable<Order> {
    const url = "orders/save";
    return this.httpService.doPost(url, order).pipe(
      map(data => {
        return data ? new Order(data) : null;
      })
    );
  }

  updateOrder(order: OrderDetailRequest): Observable<boolean> {
    const url = "orders/update";
    return this.httpService.doPost(url, order).pipe(
      map(data => {
        return data;
      })
    );
  }

  getAll(
    filter: OrderFilter,
    pageIndex: number,
    pageSize: number
  ): Observable<PagedList<Order>> {
    const url = "orders/get?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    return this.httpService.doGet(url, toQueryString(filter));
  }

  get(id: string): Observable<Order> {
    const url = "orders/get/" + id;
    return this.httpService.doGet(url, null);
  }
}
