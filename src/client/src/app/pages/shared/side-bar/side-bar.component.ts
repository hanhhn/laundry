import { Component, OnInit, Output, EventEmitter } from "@angular/core";

@Component({
  selector: "app-side-bar",
  templateUrl: "./side-bar.component.html",
  styleUrls: ["./side-bar.component.scss"]
})
export class SideBarComponent implements OnInit {
  desktopLinks = [
    { path: "ve-chung-toi", label: "Về chúng tôi" },
    { path: "dich-vu-va-quy-trinh", label: "Dịch vụ" },
    { path: "bang-gia", label: "Bảng giá" },
    { path: "lien-he", label: "Liên hệ" },
    { path: "dat-ngay", label: "Đặt ngay" }
  ];

  @Output() toggleSideBar = new EventEmitter();
  toggle = false;

  constructor() {}

  ngOnInit() {}

  onItemClick() {
    this.toggle = !this.toggle;
    this.toggleSideBar.emit(this.toggle);
  }
}
