import { Component, OnInit, Input } from "@angular/core";
import { Item } from "src/app/cores/models/item.model";

@Component({
  selector: "app-service",
  templateUrl: "./service.component.html",
  styleUrls: ["./service.component.scss"]
})
export class ServiceComponent implements OnInit {
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

  @Input()
  dataSource: Item[];

  constructor() {}

  ngOnInit() {}
}
