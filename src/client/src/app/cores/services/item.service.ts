import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { Item, ItemRequest } from "../models/item.model";
import { map } from "rxjs/operators";
import { PagedList } from "../models/paged.model";

@Injectable()
export class ItemService {
  constructor(private httpService: HttpService) {}

  get(id: number): Observable<Item> {
    const url = "items/get/" + id;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data;
      })
    );
  }

  getAll(pageIndex: number, pageSize: number): Observable<PagedList<Item>> {
    const url = "items/get?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new PagedList(data) : null;
      })
    );
  }

  saveItem(item: ItemRequest): Observable<Item> {
    const url = "items/save";
    return this.httpService.doPost(url, item).pipe(
      map((data: any) => {
        return data ? new Item(data) : null;
      })
    );
  }

  deleteItem(id: number): Observable<boolean> {
    const url = "items/delete/" + id;
    return this.httpService.doDelete(url, null).pipe(
      map((data: any) => {
        return data;
      })
    );
  }
}
