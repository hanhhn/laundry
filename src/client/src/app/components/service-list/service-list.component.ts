import { Component, OnInit, Input } from "@angular/core";

@Component({
  selector: "app-service-list",
  templateUrl: "./service-list.component.html",
  styleUrls: ["./service-list.component.scss"]
})
export class ServiceListComponent implements OnInit {
  @Input()
  dataSource = [
    {
      title: "item 1",
      description: "asdasd sfdf",
      rate: "10k"
    },
    {
      title: "item 2",
      description: "asda asd",
      rate: "20k"
    },
    {
      title: "item 3",
      description: "123asd ad",
      rate: "40k"
    }
  ];

  constructor() {}

  ngOnInit() {}
}
