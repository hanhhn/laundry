import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import {
  Menu,
  Company,
  Reason,
  Jumbotron,
  Guide
} from "../models/setting.model";

@Injectable()
export class SettingService {
  constructor(private httpService: HttpService) {}

  getMenu(): Menu[] {
    return [
      new Menu({
        desktopOrder: 1,
        mobileOrder: 3,
        mobile: false,
        url: "/ve-chung-toi",
        label: "Về chúng tôi"
      }),
      // new Menu({
      //   desktopOrder: 2,
      //   mobileOrder: 3,
      //   mobile: true,
      //   url: "/quy-trinh",
      //   label: "Quy trình"
      // }),
      new Menu({
        desktopOrder: 3,
        mobileOrder: 2,
        mobile: true,
        url: "/bang-gia",
        label: "Bảng giá"
      }),
      new Menu({
        desktopOrder: 2,
        mobileOrder: 4,
        mobile: true,
        url: "/lien-he",
        label: "Liên hệ"
      }),
      new Menu({
        desktopOrder: 1,
        mobileOrder: 1,
        mobile: true,
        url: "/dat-ngay",
        label: "Đặt ngay"
      })
    ];
  }

  getCompanyInfo(): Observable<Company> {
    const url = "settings/companyinfo";
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new Company(data) : null;
      })
    );
  }

  saveCompanyInfo(company: Company): Observable<boolean> {
    const url = "settings/companyinfo/save";
    return this.httpService.doPost(url, company).pipe(
      map((data: any) => {
        return data ? data : false;
      })
    );
  }

  getReason(): Observable<Reason> {
    const url = "settings/reason";
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new Reason(data) : null;
      })
    );
  }

  saveReason(setting: Reason): Observable<boolean> {
    const url = "settings/reason/save";
    return this.httpService.doPost(url, setting).pipe(
      map((data: any) => {
        return data ? data : false;
      })
    );
  }

  getJumbotron(): Observable<Jumbotron> {
    const url = "settings/jumbotron";
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new Jumbotron(data) : null;
      })
    );
  }

  saveJumbotron(setting: Jumbotron): Observable<boolean> {
    const url = "settings/jumbotron/save";
    return this.httpService.doPost(url, setting).pipe(
      map((data: any) => {
        return data ? data : false;
      })
    );
  }

  getProcessPost(): Observable<string[]> {
    const url = "settings/process";
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? data : [];
      })
    );
  }

  saveProcessPost(setting: string[]): Observable<boolean> {
    const url = "settings/process/save";
    return this.httpService.doPost(url, setting).pipe(
      map((data: any) => {
        return data ? data : false;
      })
    );
  }

  getGuides(): Observable<Guide> {
    const url = "settings/guide";
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new Guide(data) : null;
      })
    );
  }

  saveGuides(setting: Guide): Observable<boolean> {
    const url = "settings/guide/save";
    return this.httpService.doPost(url, setting).pipe(
      map((data: any) => {
        return data ? data : false;
      })
    );
  }

  getCombo(): Observable<Jumbotron> {
    const url = "settings/combo";
    return this.httpService.doGet(url, null).pipe(
      map((data: any) => {
        return data ? new Jumbotron(data) : null;
      })
    );
  }

  saveCombo(setting: Jumbotron): Observable<boolean> {
    const url = "settings/combo/save";
    return this.httpService.doPost(url, setting).pipe(
      map((data: any) => {
        return data ? data : false;
      })
    );
  }
}
