import { Component, OnInit } from "@angular/core";
import { Reason, Jumbotron } from "src/app/cores/models/setting.model";
import { SettingService } from "src/app/cores/services/setting.service";
import { forkJoin } from "rxjs";
import { SniperService } from "src/app/cores/services/sniper.service";
import { Post } from "../../../cores/models/post.model";
import { PostService } from "../../../cores/services/post.service";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"]
})
export class HomeComponent implements OnInit {
  carousel: Jumbotron;
  selection: Reason;
  posts: Post[];

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
      this.postService.getHomePost(0, 4)
    ]).subscribe(
      ([carousel, selection, posts]) => {
        this.carousel = carousel;
        this.selection = selection;
        this.posts = posts;

        this.sniper.hideSniper();
      },
      err => {
        this.sniper.hideSniper();
      }
    );
  }
}
