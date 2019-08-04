import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-header",
  templateUrl: "./header.component.html",
  styleUrls: ["./header.component.scss"]
})
export class HeaderComponent implements OnInit {
  desktopLinks = [
    { path: "ve-chung-toi", label: "Về chúng tôi" },
    { path: "dich-vu-va-quy-trinh", label: "Dịch vụ" },
    { path: "bang-gia", label: "Bảng giá" },
    { path: "lien-he", label: "Liên hệ" },
    { path: "dat-ngay", label: "Đặt ngay" }
  ];

  mobileLinks = [
    { path: "dat-ngay", label: "Đặt ngay" },
    { path: "bang-gia", label: "Bảng giá" },
    { path: "dich-vu-va-quy-trinh", label: "Dịch vụ" }
  ];


  active = "";

  constructor() {}

  ngOnInit() {}
}
