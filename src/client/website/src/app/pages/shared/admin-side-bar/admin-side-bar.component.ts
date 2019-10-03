import { Component, Input } from "@angular/core";
import { MenuItem } from "primeng/api";

@Component({
  selector: "app-admin-side-bar",
  templateUrl: "./admin-side-bar.component.html",
  styleUrls: ["./admin-side-bar.component.scss"]
})
export class AdminSideBarComponent {
  @Input()
  items: MenuItem[];

  constructor() {
    this.items = [];
  }
}
