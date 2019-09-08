import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { OrderRequest, Order } from "../models/orders.model";

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
}
