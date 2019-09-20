import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { OrderHistory } from "../models/orders.model";

@Injectable()
export class TrackingService {
  constructor(private httpService: HttpService) {}

  order(phone: string, code: string): Observable<OrderHistory> {
    const url = "trackings/" + phone + "/" + code;
    return this.httpService.doPost(url, null).pipe(
      map(data => {
        return data ? new OrderHistory(data) : null;
      })
    );
  }
}
