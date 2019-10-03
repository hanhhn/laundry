import { Component, OnInit, Input } from "@angular/core";

@Component({
  selector: "app-combo",
  templateUrl: "./combo.component.html",
  styleUrls: ["./combo.component.scss"]
})
export class ComboComponent implements OnInit {
  @Input()
  title: string;

  @Input()
  combo: string;

  @Input()
  delivery: string;

  @Input()
  description: string;

  @Input()
  rate: number;

  constructor() {}

  ngOnInit() {}
}
