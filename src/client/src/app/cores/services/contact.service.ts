import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { ContactRequest } from "../models/contact.model";

@Injectable()
export class ContactService {
  constructor(private httpService: HttpService) {}

  save(request: ContactRequest): Observable<boolean> {
    const url = "contact/save";
    return this.httpService.doPost(url, request);
  }
}
