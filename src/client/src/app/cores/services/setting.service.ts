import { Injectable } from "@angular/core";
import { Menu } from "../models/setting.model";

@Injectable()
export default class SettingService {
  constructor() {}

  getMenu(): Menu[] {
    return [
      new Menu({
        desktopOrder: 1,
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
        desktopOrder: 5,
        mobileOrder: 1,
        mobile: true,
        url: "/dat-ngay",
        label: "Đặt ngay"
      })
    ];
  }
}
