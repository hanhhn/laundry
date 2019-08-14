import { Component, OnInit, Input } from "@angular/core";

@Component({
  selector: "app-service-item",
  templateUrl: "./service-item.component.html",
  styleUrls: ["./service-item.component.scss"]
})
export class ServiceItemComponent implements OnInit {
  @Input()
  title: string;

  @Input()
  description: string;

  @Input()
  rate: string;

  constructor() {}

  ngOnInit() {}
}
