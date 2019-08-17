import { Component, OnInit, Output, EventEmitter, Input } from "@angular/core";
import { Menu } from "../../../cores/models/setting.model";

@Component({
  selector: "app-side-bar",
  templateUrl: "./side-bar.component.html",
  styleUrls: ["./side-bar.component.scss"]
})
export class SideBarComponent implements OnInit {
  @Input()
  menuLinks: Menu[];

  @Output() toggleSideBar = new EventEmitter();
  toggle = false;

  constructor() {}

  ngOnInit() {}

  onItemClick() {
    this.toggle = !this.toggle;
    this.toggleSideBar.emit(this.toggle);
  }

  get getMenuDesktop(): Menu[] {
    if (this.menuLinks) {
      return this.menuLinks.sort((a, b) => {
        if (a.desktopOrder > b.desktopOrder) {
          return 1;
        }

        if (a.desktopOrder === b.desktopOrder) {
          return 0;
        }

        return -1;
      });
    }

    return [];
  }
}
