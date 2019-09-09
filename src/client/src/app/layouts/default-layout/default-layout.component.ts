import { Component, OnInit } from "@angular/core";
import { SettingService } from "../../cores/services/setting.service";
import { Menu, Company } from "../../cores/models/setting.model";
import { SniperService } from "../../cores/services/sniper.service";
import {
  Router,
  NavigationEnd,
  NavigationStart,
  NavigationError
} from "@angular/router";

@Component({
  selector: "app-default-layout",
  templateUrl: "./default-layout.component.html",
  styleUrls: ["./default-layout.component.scss"]
})
export class DefaultLayoutComponent implements OnInit {
  menuLinks: Menu[];

  company: Company;

  brand: string;

  constructor(
    private router: Router,
    private sniper: SniperService,
    private setting: SettingService
  ) {}

  ngOnInit() {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationStart) {
        this.sniper.showSniper();
      }

      if (event instanceof NavigationEnd) {
        this.sniper.hideSniper();
      }

      if (event instanceof NavigationError) {
        this.sniper.hideSniper();
      }
    });

    this.menuLinks = this.setting.getMenu();

    this.sniper.showSniper();
    this.setting.getCompanyInfo().subscribe(
      data => {
        this.company = data;
        this.brand = data ? data.brand : "GIẶT SẠCH";

        this.sniper.hideSniper();
      },
      err => {
        this.sniper.hideSniper();
      }
    );
  }
}
