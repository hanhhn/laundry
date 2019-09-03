import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { PagedList } from "../models/paged.model";
import { Method } from "../models/method.model";

@Injectable()
export class MethodService {
  constructor(private httpService: HttpService) {}

  getApplyMethod(
    pageIndex: number,
    pageSize: number
  ): Observable<PagedList<Method>> {
    const url =
      "methods/apply?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new PagedList(data) : null;
      })
    );
  }


  getCleanMethod(
    pageIndex: number,
    pageSize: number
  ): Observable<PagedList<Method>> {
    const url =
      "methods/clean?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new PagedList(data) : null;
      })
    );
  }

  getSoftMethod(
    pageIndex: number,
    pageSize: number
  ): Observable<PagedList<Method>> {
    const url = "methods/soft?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new PagedList(data) : null;
      })
    );
  }

  getDryMethod(
    pageIndex: number,
    pageSize: number
  ): Observable<PagedList<Method>> {
    const url = "methods/dry?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new PagedList(data) : null;
      })
    );
  }

  getStraightMethod(
    pageIndex: number,
    pageSize: number
  ): Observable<PagedList<Method>> {
    const url =
      "methods/straight?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new PagedList(data) : null;
      })
    );
  }
}
