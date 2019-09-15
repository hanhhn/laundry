import { Component, OnInit } from "@angular/core";
import { Reason, Jumbotron } from "src/app/cores/models/setting.model";
import { SettingService } from "src/app/cores/services/setting.service";
import { forkJoin } from "rxjs";
import { SniperService } from "src/app/cores/services/sniper.service";
import { Post, GuidePost } from "../../../cores/models/post.model";
import { PostService } from "../../../cores/services/post.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"]
})
export class HomeComponent implements OnInit {
  carousel: Jumbotron;
  selection: Reason;
  process: Post[];
  guide: GuidePost;

  constructor(
    private setting: SettingService,
    private postService: PostService,
    private sniper: SniperService
  ) {}

  ngOnInit() {
    this.sniper.showSniper();
    forkJoin([
      this.setting.getJumbotron(),
      this.setting.getReason(),
      this.postService.getProcessPost(0, 4),
      this.postService.getGuidePost(0, 10)
    ]).subscribe(
      ([carousel, selection, process, guide]) => {
        this.carousel = carousel;
        this.selection = selection;
        this.process = process;
        this.guide = guide;

        this.sniper.hideSniper();
      },
      err => {
        this.sniper.hideSniper();
      }
    );
  }
}
