import { Component, OnInit } from "@angular/core";

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { position: 1, name: "Hydrogen", weight: 1.0079, symbol: "H" },
  { position: 2, name: "Helium", weight: 4.0026, symbol: "He" },
];

@Component({
  selector: "app-service",
  templateUrl: "./service.component.html",
  styleUrls: ["./service.component.scss"]
})
export class ServiceComponent implements OnInit {
  displayedColumns = [
    "name",
    "position",
    "weight",
    "symbol",
    "position",
    "weight",
    "symbol",
    "star"
  ];
  dataSource = ELEMENT_DATA;

  display = false;

  constructor() {}

  ngOnInit() {}

  onShowAddDialog() {
    this.display = true;
  }
}
