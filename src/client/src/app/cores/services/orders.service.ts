import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { OrderRequest, Order, OrderFilter } from "../models/orders.model";
import { toQueryString } from "../helpers/utils.helper";
import { PagedList } from "../models/paged.model";

@Injectable()
export class OrdersService {
  constructor(private httpService: HttpService) {}

  saveOrder(method: OrderRequest): Observable<Order> {
    const url = "orders/save";
    return this.httpService.doPost(url, method).pipe(
      map(data => {
        return data ? new Order(data) : null;
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
