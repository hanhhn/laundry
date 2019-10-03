import { Component, OnInit, Input } from "@angular/core";

@Component({
  selector: "app-jumbotron",
  templateUrl: "./jumbotron.component.html",
  styleUrls: ["./jumbotron.component.scss"]
})
export class JumbotronComponent {
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
