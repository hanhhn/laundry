import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Page, PageRequest } from "../models/page.model";
import { PagedList } from "../models/paged.model";

@Injectable()
export class PageService {
  constructor(private httpService: HttpService) {}

  getByUrl(uniquerUrl: string): Observable<Page> {
    const url = "pages/get/" + uniquerUrl;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new Page(data) : null;
      })
    );
  }

  getById(id: string): Observable<Page> {
    const url = "pages/detail/" + id;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new Page(data) : null;
      })
    );
  }

  getAll(pageIndex: number, pageSize: number): Observable<PagedList<Page>> {
    const url = "pages/get?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new PagedList(data) : null;
      })
    );
  }

  isUniqueUrl(uniqueUrl: string): Observable<boolean> {
    const url = "pages/unique/" + uniqueUrl;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? data : false;
      })
    );
  }

  save(item: PageRequest): Observable<boolean> {
    const url = "pages/save";
    return this.httpService.doPost(url, item).pipe(
      map((data: any) => {
        return data;
      })
    );
  }

  delete(id: string): Observable<boolean> {
    const url = "pages/delete/" + id;
    return this.httpService.doDelete(url, null).pipe(
      map((data: any) => {
        return data;
      })
    );
  }
}
