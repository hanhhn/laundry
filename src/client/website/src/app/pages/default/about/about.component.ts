import { Component, OnInit } from "@angular/core";
import { SettingService } from "src/app/cores/services/setting.service";
import { Reason } from "src/app/cores/models/setting.model";

@Component({
  selector: "app-about",
  templateUrl: "./about.component.html",
  styleUrls: ["./about.component.scss"]
})
export class AboutComponent implements OnInit {
  selection: Reason;

  constructor(private setting: SettingService) {}

  ngOnInit() {
    this.setting.getReason().subscribe(data => {
      this.selection = data;
    });
  }
}
