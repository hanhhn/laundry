import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { PagedList } from "../models/paged.model";
import { Price, PriceRequest } from "../models/price.model";

@Injectable()
export class PriceService {
  constructor(private httpService: HttpService) {}

  get(id: number): Observable<Price> {
    const url = "prices/get/" + id;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data;
      })
    );
  }

  getAll(pageIndex: number, pageSize: number): Observable<PagedList<Price>> {
    const url = "prices/get?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new PagedList(data) : null;
      })
    );
  }

  saveRate(item: PriceRequest): Observable<Price> {
    const url = "prices/save";
    return this.httpService.doPost(url, item).pipe(
      map((data: any) => {
        return data ? new Price(data) : null;
      })
    );
  }

  deleteRate(id: number): Observable<boolean> {
    const url = "prices/delete/" + id;
    return this.httpService.doDelete(url, null).pipe(
      map((data: any) => {
        return data;
      })
    );
  }
}
