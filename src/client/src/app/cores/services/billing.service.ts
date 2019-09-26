import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Bill } from "../models/billing.model";

@Injectable()
export class BillingService {
  constructor(private httpService: HttpService) {}

  publish(orderId: string): Observable<Bill> {
    const url = "billing/publish/";
    return this.httpService.doPost(url, orderId).pipe(
      map(data => {
        return data ? new Bill(data) : null;
      })
    );
  }

  get(id: string): Observable<Bill> {
    const url = "billing/get/" + id;
    return this.httpService.doGet(url, null).pipe(
      map(data => {
        return data ? new Bill(data) : null;
      })
    );
  }
}
