import {
  Http,
  RequestOptionsArgs,
  ResponseContentType,
  Headers
} from "@angular/http";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";

const apiUrl = "";
const tokenKey = "";

@Injectable()
export class HttpService {
  addToken = false;

  constructor(private http: Http) {}

  doGet(url: string, requestParams: string): Observable<any> {
    const requestOptions: RequestOptionsArgs = {
      responseType: ResponseContentType.Json,
      params: requestParams
    };

    if (this.addToken) {
      const token = "Bearer " + localStorage.getItem(tokenKey);
      const headers = new Headers();
      headers.append("Authorization", token);
      headers.append("Content-Type", "application/json; charset=utf-8");
      requestOptions.headers = headers;
    }

    const reqUrl: string = apiUrl + url;

    return this.http.get(reqUrl, requestOptions);
  }

  doPost(url: string, bodyParams: any): Observable<any> {
    const hders = new Headers({
      "Content-Type": "application/json; charset=utf-8"
    });

    if (this.addToken) {
      const token = "Bearer " + localStorage.getItem(tokenKey);
      hders.append("Authorization", token);
    }

    const requestOptions: RequestOptionsArgs = {
      responseType: ResponseContentType.Text,
      headers: hders
    };

    const body: any = JSON.stringify(bodyParams);
    const reqUrl: string = apiUrl + url;

    return this.http.post(reqUrl, body, requestOptions);
  }

  doPut(url: string, bodyParams: any): Observable<any> {
    const hders = new Headers({
      "Content-Type": "application/json; charset=utf-8"
    });
    if (this.addToken) {
      const token = "Bearer " + localStorage.getItem(tokenKey);
      hders.append("Authorization", token);
    }

    const requestOptions: RequestOptionsArgs = {
      responseType: ResponseContentType.Json,
      headers: hders
    };
    const body: any = JSON.stringify(bodyParams);
    const reqUrl: string = apiUrl + url;

    return this.http.put(reqUrl, body, requestOptions);
  }

  doDelete(url: string, requestParams: string): Observable<any> {
    const hders = new Headers({
      "Content-Type": "application/json; charset=utf-8"
    });
    if (this.addToken) {
      const token = "Bearer " + localStorage.getItem(tokenKey);
      hders.append("Authorization", token);
    }

    const requestOptions: RequestOptionsArgs = {
      responseType: ResponseContentType.Text,
      params: requestParams,
      headers: hders
    };
    const reqUrl: string = apiUrl + url;

    return this.http.delete(reqUrl, requestOptions);
  }
}
