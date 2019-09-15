import { Component, OnInit, Input, OnChanges } from "@angular/core";
import { Post } from "../../cores/models/post.model";

@Component({
  selector: "app-post-list",
  templateUrl: "./post-list.component.html",
  styleUrls: ["./post-list.component.scss"]
})
export class PostListComponent implements OnChanges {
  @Input()
  dataSource: Post[];

  left: Post[];

  right: Post[];

  constructor() {
    this.left = [];
    this.right = [];
  }

  ngOnChanges() {
    console.log(this.dataSource);
    if (this.dataSource) {
      const reasons = this.dataSource
        .reverse()
        .slice(0, 4);

      reasons.forEach((value, index) => {
        if (index > 1) {
          this.right.push(value);
        } else {
          this.left.push(value);
        }
      });
    }
  }
}
