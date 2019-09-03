import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
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

  getCleanMethod(
    pageIndex: number,
    pageSize: number
  ): Observable<PagedList<Method>> {
    const url =
      "methods/clean?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    return this.httpService.doGet(url, null).pipe(map(this.mapData));
  }

  getSoftMethod(
    pageIndex: number,
    pageSize: number
  ): Observable<PagedList<Method>> {
    const url = "methods/soft?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    return this.httpService.doGet(url, null).pipe(map(this.mapData));
  }

  getDryMethod(
    pageIndex: number,
    pageSize: number
  ): Observable<PagedList<Method>> {
    const url = "methods/dry?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    return this.httpService.doGet(url, null).pipe(map(this.mapData));
  }

  getStraightMethod(
    pageIndex: number,
    pageSize: number
  ): Observable<PagedList<Method>> {
    const url =
      "methods/straight?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
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

  getMethodTypes(): KeyValue[] {
    return [
      new KeyValue(1, "Clean"),
      new KeyValue(2, "Soft"),
      new KeyValue(3, "Dry"),
      new KeyValue(4, "Straight")
    ];
  }

  private mapData(data: any): PagedList<Method> {
    return data ? new PagedList(data) : null;
  }
}
