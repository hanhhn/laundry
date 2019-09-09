import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { Menu, Company } from "../models/setting.model";

@Injectable()
export class SettingService {
  constructor(private httpService: HttpService) {}

  getMenu(): Menu[] {
    return [
      new Menu({
        desktopOrder: 5,
        mobileOrder: 1,
        mobile: false,
        url: "/ve-chung-toi",
        label: "Về chúng tôi"
      }),
      new Menu({
        desktopOrder: 2,
        mobileOrder: 3,
        mobile: true,
        url: "/quy-trinh",
        label: "Quy trình"
      }),
      new Menu({
        desktopOrder: 3,
        mobileOrder: 2,
        mobile: true,
        url: "/bang-gia",
        label: "Bảng giá"
      }),
      new Menu({
        desktopOrder: 4,
        mobileOrder: 1,
        mobile: false,
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

 // giatsach.vn@outlook.com | giatsach2019
  getCompanyInfo(): Observable<Company> {
    const url = "settings/companyinfo/get";
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
}
