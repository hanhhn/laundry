import { Component, OnInit } from "@angular/core";
import { SettingService } from "../../cores/services/setting.service";
import { Menu, Company } from "../../cores/models/setting.model";

@Component({
  selector: "app-default-layout",
  templateUrl: "./default-layout.component.html",
  styleUrls: ["./default-layout.component.scss"]
})
export class DefaultLayoutComponent implements OnInit {
  menuLinks: Menu[];

  company: Company;

  brand: string;

  constructor(private setting: SettingService) {}

  ngOnInit() {
    this.menuLinks = this.setting.getMenu();
    this.setting.getCompanyInfo().subscribe(data => {
      this.company = data;
      this.brand = data ? data.brand : "GIẶT SẠCH";
    });
  }
}
