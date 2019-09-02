import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { ItemRate, ItemRateRequest } from "../models/item.model";
import { map } from "rxjs/operators";
import { PagedList } from "../models/paged.model";

@Injectable()
export class ItemRateService {
  constructor(private httpService: HttpService) {}

  get(id: number): Observable<ItemRate> {
    const url = "rates/get/" + id;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data;
      })
    );
  }

  getAll(pageIndex: number, pageSize: number): Observable<PagedList<ItemRate>> {
    const url = "rates/get?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new PagedList(data) : null;
      })
    );
  }

  saveRate(item: ItemRateRequest): Observable<ItemRate> {
    const url = "rates/save";
    return this.httpService.doPost(url, item).pipe(
      map((data: any) => {
        return data ? new ItemRate(data) : null;
      })
    );
  }

  deleteRate(id: number): Observable<boolean> {
    const url = "rates/delete/" + id;
    return this.httpService.doDelete(url, null).pipe(
      map((data: any) => {
        return data;
      })
    );
  }
}
