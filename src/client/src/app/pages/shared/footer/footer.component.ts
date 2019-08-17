import { Component, OnInit, Input } from "@angular/core";
import { Company, Link } from "../../../cores/models/setting.model";

@Component({
  selector: "app-footer",
  templateUrl: "./footer.component.html",
  styleUrls: ["./footer.component.scss"]
})
export class FooterComponent implements OnInit {
  @Input()
  company: Company;

  @Input()
  socialLink: Link;

  constructor() {}

  ngOnInit() {}
}
