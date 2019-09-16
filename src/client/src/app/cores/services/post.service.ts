import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Post, PostRequest, GuidePost } from "../models/post.model";
import { PagedList } from "../models/paged.model";

@Injectable()
export class PostService {
  constructor(private httpService: HttpService) {}

  getByUrl(uniquerUrl: string): Observable<Post> {
    const url = "posts/get/" + uniquerUrl;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new Post(data) : null;
      })
    );
  }

  getById(id: string): Observable<Post> {
    const url = "posts/detail/" + id;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new Post(data) : null;
      })
    );
  }

  getAll(pageIndex: number, pageSize: number): Observable<PagedList<Post>> {
    const url = "posts/get?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new PagedList(data) : null;
      })
    );
  }

  isUniqueUrl(uniqueUrl: string): Observable<boolean> {
    const url = "posts/unique/" + uniqueUrl;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? data : false;
      })
    );
  }

  save(item: PostRequest): Observable<boolean> {
    const url = "posts/save";
    return this.httpService.doPost(url, item).pipe(
      map((data: any) => {
        return data;
      })
    );
  }

  delete(id: string): Observable<boolean> {
    const url = "posts/delete/" + id;
    return this.httpService.doDelete(url, null).pipe(
      map((data: any) => {
        return data;
      })
    );
  }

  getProcessPost(pageIndex: number, pageSize: number): Observable<Post[]> {
    const url =
      "posts/process?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? data.map(x => new Post(x)) : [];
      })
    );
  }

  getGuidePost(pageIndex: number, pageSize: number): Observable<GuidePost> {
    const url = "posts/guide?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new GuidePost(data) : null;
      })
    );
  }
}
