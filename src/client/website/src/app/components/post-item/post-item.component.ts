import { Component, OnInit, Input } from "@angular/core";

@Component({
  selector: "app-post-item",
  templateUrl: "./post-item.component.html",
  styleUrls: ["./post-item.component.scss"]
})
export class PostItemComponent implements OnInit {
  @Input()
  image: string;

  @Input()
  title: string;

  @Input()
  description: string[];

  constructor() {}

  ngOnInit() {}
}
