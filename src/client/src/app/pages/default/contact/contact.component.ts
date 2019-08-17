import { Component, OnInit } from "@angular/core";
import { Company } from "../../../cores/models/setting.model";
import SettingService from "../../../cores/services/setting.service";
import { DomSanitizer, SafeUrl } from "@angular/platform-browser";

@Component({
  selector: "app-contact",
  templateUrl: "./contact.component.html",
  styleUrls: ["./contact.component.scss"]
})
export class ContactComponent implements OnInit {
  companyInfo: Company;

  googleMap: SafeUrl;

  constructor() {
  }

  ngOnInit() {
    const setting = new SettingService();
    this.companyInfo = setting.getCompany();
  }
}
