import { Component, Input, OnInit } from "@angular/core";
import { Company } from "../../../cores/models/setting.model";
import { FacebookService, InitParams } from "ngx-facebook";

@Component({
  selector: "app-footer",
  templateUrl: "./footer.component.html",
  styleUrls: ["./footer.component.scss"]
})
export class FooterComponent implements OnInit {
  @Input()
  company: Company;

  constructor(private facebookService: FacebookService) {}

  ngOnInit(): void {
    this.initFacebookService();
  }
  private initFacebookService(): void {
    const initParams: InitParams = { xfbml: true, version: "v3.2" };
    this.facebookService.init(initParams);
  }
}
