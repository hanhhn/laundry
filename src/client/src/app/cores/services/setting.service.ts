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
  getCompany(): Company {
    return new Company({
      name: "Công Ty TNHH Thương Mại Công Nghệ GIAT SACH",
      address: "201/2, Lê Văn Việt, Quận 9, Hồ Chí Minh",
      phone: "0866.667.670",
      email: "giatsach.vn@outlook.com",
      brand: "GIẶT SẠCH",
      // tslint:disable-next-line:max-line-length
      logo: "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAANMAAABoCAIAAADkaFI4AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAHgSURBVHhe7djBjeJAEEDRiYuAHA/ROBmCYQ0YsJcZeW+/Nfveja6u25db4usKBeXRUB4N5dFQHg3l0VAeDeXRUB4N5dFQHg3l0VAeDeXRUB4N5dFQHg3l0VAeDeXRUB4N5dFQHg3l0VAeDeXRUB4N5dFQHg3l0VAeDeXRUB4N5dEYqbzL+fR1dzpf1qPFZZ5O6/kymc7zZnazm0/zevpwtEtn7PJeJzubMJey1sOHTXmHu6RGLm+eHj+/8Sjs88KrvMNdYgOX947ntD6Ty+O5ntyubD5qzwsvR7v3S5TGLe9VyjaUd23TvL+wnRzvrkd0fmF5H6OV8obyO17bad6/vbuLXtshDVne4rR9Mz89vlo/XLgND3eJjVTerpd7H9sW3zbfrL//VVk8p4e7pMYq79bL2tLzy3RZnsl//id5GW+nh7t0RiuP/4XyaCiPhvJoKI+G8mgoj4byaCiPhvJoKI+G8mgoj4byaCiPhvJoKI+G8mgoj4byaCiPhvJoKI+G8mgoj4byaCiPhvJoKI+G8mgoj4byaCiPhvJoKI+G8mgoj4byaCiPhvJoKI+G8mgoj4byaCiPhvJoKI+G8mgoj4byaCiPhvJoKI+G8mgoj4byaCiPhvJoKI+G8ihcr38ADzyhzws2inQAAAAASUVORK5CYII=",
      website: "Giatsach.vn",
      copyright: "<h4>Copyright © 2019 GiatSach</h4>",
      // tslint:disable-next-line:max-line-length
      map: "https://www.google.com/maps/embed?pb=!1m10!1m8!1m3!1d13565.919162068974!2d106.79703418599895!3d10.860553916448039!3m2!1i1024!2i768!4f13.1!5e0!3m2!1svi!2sus!4v1565881781323!5m2!1svi!2sus"
    });
  }

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
