import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { AddressUnit, Address, AddressRequest } from "../models/address.model";

@Injectable()
export class AddressService {
  constructor(private httpService: HttpService) {}

  getProvince(): Observable<AddressUnit[]> {
    const url = "address/province/get";
    return this.httpService.doGet(url, null).pipe(map(this.mapAddressUnit));
  }

  getDistrict(provinceId: number): Observable<AddressUnit[]> {
    const url = "address/district/get/" + provinceId;
    return this.httpService.doGet(url, null).pipe(map(this.mapAddressUnit));
  }

  getWard(districtId: number): Observable<AddressUnit[]> {
    const url = "address/ward/get/" + districtId;
    return this.httpService.doGet(url, null).pipe(map(this.mapAddressUnit));
  }

  getFullAddress(phone: string): Observable<Address[]> {
    const url = "address/get/" + phone;
    return this.httpService.doGet(url, null).pipe(map(this.mapAddress));
  }

  save(request: AddressRequest): Observable<Address[]> {
    const url = "address/save";
    return this.httpService.doPost(url, request).pipe(map(this.mapAddress));
  }

  setDefault(request: AddressRequest): Observable<Address[]> {
    const url = "address/default";
    return this.httpService.doPost(url, request).pipe(map(this.mapAddress));
  }

  private mapAddressUnit(data: any): AddressUnit[] {
    return data ? data.map(x => (x ? new AddressUnit(x) : null)) : [];
  }

  private mapAddress(data: any): Address[] {
    return data ? data.map(x => new Address(x)) : [];
  }
}
