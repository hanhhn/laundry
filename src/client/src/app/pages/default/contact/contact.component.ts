import { Component, OnInit } from "@angular/core";
import { Company } from "../../../cores/models/setting.model";
import { DomSanitizer, SafeUrl } from "@angular/platform-browser";
import { SettingService } from "src/app/cores/services/setting.service";

@Component({
  selector: "app-contact",
  templateUrl: "./contact.component.html",
  styleUrls: ["./contact.component.scss"]
})
export class ContactComponent implements OnInit {
  companyInfo: Company;

  googleMap: SafeUrl;

  constructor(private setting: SettingService) {}

  ngOnInit() {
    this.setting.getCompanyInfo().subscribe(data => {
      this.companyInfo = data;
    });
  }
}
