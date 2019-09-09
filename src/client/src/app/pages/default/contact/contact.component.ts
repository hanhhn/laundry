import { Component, OnInit } from "@angular/core";
import { Company } from "../../../cores/models/setting.model";
import { DomSanitizer, SafeUrl } from "@angular/platform-browser";
import { SettingService } from "src/app/cores/services/setting.service";
import { SniperService } from "../../../cores/services/sniper.service";

@Component({
  selector: "app-contact",
  templateUrl: "./contact.component.html",
  styleUrls: ["./contact.component.scss"]
})
export class ContactComponent implements OnInit {
  companyInfo: Company;

  googleMap: SafeUrl;

  constructor(private sniper: SniperService, private setting: SettingService) {}

  ngOnInit() {
    this.sniper.showSniper();
    this.setting.getCompanyInfo().subscribe(
      data => {
        this.companyInfo = data;
        this.sniper.hideSniper();
      },
      err => {
        this.sniper.hideSniper();
      }
    );
  }
}
