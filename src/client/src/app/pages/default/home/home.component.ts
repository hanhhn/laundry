import { Component, OnInit } from "@angular/core";
import { Reason, Jumbotron } from "src/app/cores/models/setting.model";
import { SettingService } from "src/app/cores/services/setting.service";
import { fork } from "cluster";
import { forkJoin } from "rxjs";
import { SniperService } from "src/app/cores/services/sniper.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"]
})
export class HomeComponent implements OnInit {
  carousel: Jumbotron;
  selection: Reason;

  constructor(private setting: SettingService, private sniper: SniperService) {}

  ngOnInit() {
    this.sniper.showSniper();
    forkJoin([this.setting.getJumbotron(), this.setting.getReason()]).subscribe(
      ([carousel, selection]) => {
        this.carousel = carousel;
        this.selection = selection;

        this.sniper.hideSniper();
      },
      err => {
        this.sniper.hideSniper();
      }
    );
  }
}
