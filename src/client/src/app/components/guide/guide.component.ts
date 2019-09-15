import { Component, OnInit, Input, OnDestroy } from "@angular/core";
import { map } from "rxjs/operators";
import { Post } from "../../cores/models/post.model";

@Component({
  selector: "app-guide",
  templateUrl: "./guide.component.html",
  styleUrls: ["./guide.component.scss"]
})
export class GuideComponent implements OnInit, OnDestroy {
  @Input()
  title: string;

  @Input()
  description: string;

  @Input()
  background: string;

  @Input()
  dataSource: Post[];

  steps = [];

  activeItem: any;

  i: number;

  loop: any;

  constructor() {
    this.i = 0;
  }

  ngOnInit() {
    if (this.dataSource) {
      this.dataSource.map(x => {
        this.steps.push(false);
      });

      this.steps[0] = true;

      const post = this.dataSource[0];
      this.activeItem = {
        title: post.title,
        description: post.description
      };

      this.loop = setInterval(() => {
        this.move(this.i++ % this.dataSource.length);
      }, 4000);
    }
  }

  ngOnDestroy(): void {
    clearInterval(this.loop);
  }

  onMoveClicked(i) {
    this.move(i);
  }

  move(i) {
    this.steps.forEach((value, index) => {
      this.steps[index] = false;
    });

    this.steps[i] = true;
    const post = this.dataSource[i];
    this.activeItem = {
      title: post.title,
      description: post.description
    };
  }
}
