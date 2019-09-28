import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { from, of } from "rxjs";
import { PagedList } from "../models/paged.model";
import { Method, MethodRequest } from "../models/method.model";
import { KeyValue } from "../models/object.model";

@Injectable()
export class MethodService {
  constructor(private httpService: HttpService) {}

  getAll(pageIndex: number, pageSize: number): Observable<PagedList<Method>> {
    const url = "methods/get?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    return this.httpService.doGet(url, null).pipe(map(this.mapData));
  }

  getApplyMethod(
    pageIndex: number,
    pageSize: number
  ): Observable<PagedList<Method>> {
    const url =
      "methods/apply?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    return this.httpService.doGet(url, null).pipe(map(this.mapData));
  }

  save(method: MethodRequest): Observable<Method> {
    const url = "methods/save";
    return this.httpService.doPost(url, method).pipe(
      map(data => {
        return data ? new Method(data) : null;
      })
    );
  }

  delete(id: number): Observable<boolean> {
    const url = "methods/delete/" + id;
    return this.httpService.doDelete(url, null).pipe(
      map(data => {
        return data;
      })
    );
  }

  get(id: number): Observable<Method> {
    const url = "methods/get/" + id;
    return this.httpService.doGet(url, null).pipe(
      map(data => {
        return data ? new Method(data) : null;
      })
    );
  }

  getMethodTypes(): Observable<KeyValue[]> {
    const types = [
      new KeyValue("Clean", "Clean - Giặt Ủi"),
      new KeyValue("Delivery", "Delivery - Giao hàng"),
      new KeyValue("Combo", "Combo - Kết hợp"),
      new KeyValue("Other", "Other - Khác")
    ];
    return of(types);
  }

  private mapData(data: any): PagedList<Method> {
    return data ? new PagedList(data) : null;
  }
}
