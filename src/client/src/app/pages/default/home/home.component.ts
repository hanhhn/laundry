import { Component, OnInit } from "@angular/core";
import { Reason } from "src/app/cores/models/setting.model";
import { SettingService } from "src/app/cores/services/setting.service";
import { fork } from "cluster";
import { forkJoin } from "rxjs";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"]
})
export class HomeComponent implements OnInit {
  carousel = {
    title: "We love people who code  ",
    description:
      "Linux does not use extensions. It is up to the creator of the file to decide if he wants the name to have an extension.",
    strokedName: "Bảng giá",
    strokedLink: "/bang-gia",
    flatName: "Đặt ngay",
    flatLink: "/dat-ngay"
  };

  selection: Reason;

  constructor(private setting: SettingService) {}

  ngOnInit() {
    this.setting.getReason().subscribe(data => {
      this.selection = data;
    });
  }
}
