import { Component, OnInit } from "@angular/core";
import { Reason, Jumbotron } from "src/app/cores/models/setting.model";
import { SettingService } from "src/app/cores/services/setting.service";
import { forkJoin } from "rxjs";
import { SniperService } from "src/app/cores/services/sniper.service";
import { Post, GuidePost } from "../../../cores/models/post.model";
import { PostService } from "../../../cores/services/post.service";
import { ItemService } from "src/app/cores/services/item.service";
import { Item, ItemCombo } from "src/app/cores/models/item.model";

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
  combo: ItemCombo;

  constructor(
    private setting: SettingService,
    private postService: PostService,
    private itemService: ItemService,
    private sniper: SniperService
  ) {}

  ngOnInit() {
    this.sniper.showSniper();
    forkJoin([
      this.setting.getJumbotron(),
      this.itemService.getItemCombo(),
      this.setting.getReason(),
      this.postService.getProcessPost(0, 4),
      this.postService.getGuidePost(0, 10)
    ]).subscribe(
      ([carousel, itemCombo, selection, process, guide]) => {
        this.combo = itemCombo;
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
