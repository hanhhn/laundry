import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { PagedList } from "../models/paged.model";
import { AddressUnit } from "../models/address.model";

@Injectable()
export class AddressService {
  constructor(private httpService: HttpService) {}

  getProvince(): Observable<AddressUnit[]> {
    const url = "address/province/get";
    return this.httpService.doGet(url, null).pipe(map(this.mapData));
  }

  getDistrict(provinceId: number): Observable<AddressUnit[]> {
    const url = "address/district/get/" + provinceId;
    return this.httpService.doGet(url, null).pipe(map(this.mapData));
  }

  getWard(districtId: number): Observable<AddressUnit[]> {
    const url = "address/ward/get/" + districtId;
    return this.httpService.doGet(url, null).pipe(map(this.mapData));
  }

  private mapData(data: any): AddressUnit[] {
    return data ? data.map(x => (x ? new AddressUnit(x) : null)) : [];
  }
}
