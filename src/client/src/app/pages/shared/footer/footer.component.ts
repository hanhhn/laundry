import { Component, Input } from "@angular/core";
import { Company } from "../../../cores/models/setting.model";

@Component({
  selector: "app-footer",
  templateUrl: "./footer.component.html",
  styleUrls: ["./footer.component.scss"]
})
export class FooterComponent {
  @Input()
  company: Company;
}
