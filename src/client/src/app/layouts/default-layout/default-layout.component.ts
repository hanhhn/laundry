import { Component, OnInit } from "@angular/core";
import SettingService from "../../cores/services/setting.service";
import { Menu, Company, Link } from "../../cores/models/setting.model";

@Component({
  selector: "app-default-layout",
  templateUrl: "./default-layout.component.html",
  styleUrls: ["./default-layout.component.scss"]
})
export class DefaultLayoutComponent implements OnInit {
  menuLinks: Menu[];

  companyInfo: Company;

  socialLink: Link;

  ngOnInit() {
    const setting = new SettingService();
    this.menuLinks = setting.getMenu();
    this.companyInfo = setting.getCompany();
    this.socialLink = setting.getSocialLink();
  }
}
