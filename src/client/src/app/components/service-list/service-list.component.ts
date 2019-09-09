import { Component, OnInit, Input } from "@angular/core";
import { Item } from "../../cores/models/item.model";

@Component({
  selector: "app-service-list",
  templateUrl: "./service-list.component.html",
  styleUrls: ["./service-list.component.scss"]
})
export class ServiceListComponent implements OnInit {
  @Input()
  dataSource: Item[];

  constructor() {}

  ngOnInit() {}
}
