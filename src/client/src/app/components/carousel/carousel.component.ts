import { Component, OnInit, Input } from "@angular/core";

@Component({
  selector: "app-carousel",
  templateUrl: "./carousel.component.html",
  styleUrls: ["./carousel.component.scss"]
})
export class CarouselComponent {
  @Input()
  title: string;

  @Input()
  description: string;

  @Input()
  strokedName: string;

  @Input()
  strokedLink: string;

  @Input()
  flatName: string;

  @Input()
  flatLink: string;
}
