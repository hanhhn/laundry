import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable, of } from "rxjs";
import { Item, ItemRequest, ItemCombo } from "../models/item.model";
import { map } from "rxjs/operators";
import { PagedList } from "../models/paged.model";
import { KeyValue } from "../models/object.model";

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

  getLaundry(pageIndex: number, pageSize: number): Observable<PagedList<Item>> {
    const url =
      "items/laundry?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new PagedList(data) : null;
      })
    );
  }

  getDryClean(
    pageIndex: number,
    pageSize: number
  ): Observable<PagedList<Item>> {
    const url =
      "items/dryclean?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
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

  getItemCombo(): Observable<ItemCombo> {
    const url = "items/itemcombo";
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new ItemCombo(data) : null;
      })
    );
  }

  getItemTypes(): Observable<KeyValue[]> {
    const types = [
      new KeyValue("Laundry", "Laundry"),
      new KeyValue("Combo", "Combo"),
      new KeyValue("PriceList", "Price List")
    ];
    return of(types);
  }

  getItemCodes(): Observable<KeyValue[]> {
    return of([new KeyValue("Method", "Method"), new KeyValue("Item", "Item")]);
  }
}
