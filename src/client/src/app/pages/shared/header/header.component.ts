import {
  Component,
  OnInit,
  EventEmitter,
  Output,
  NgZone,
  Input,
  OnChanges
} from "@angular/core";
import { ScrollDispatcher, CdkScrollable } from "@angular/cdk/overlay";
import { map } from "rxjs/operators";
import SettingService from "../../../cores/services/setting.service";
import { Menu } from "../../../cores/models/setting.model";

@Component({
  selector: "app-header",
  templateUrl: "./header.component.html",
  styleUrls: ["./header.component.scss"]
})
export class HeaderComponent implements OnInit {
  @Input()
  menuLinks: Menu[];

  @Input()
  brand: string;

  @Output() toggleSideBar = new EventEmitter();
  toggle = false;

  private readonly SHRINK_TOP_SCROLL_POSITION = 15;
  shrinkToolbar = false;

  constructor(
    private scrollDispatcher: ScrollDispatcher,
    private ngZone: NgZone
  ) {}

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

  get getMenuMobile(): Menu[] {
    if (this.menuLinks) {
      return this.menuLinks
        .filter(x => x.mobile)
        .sort((a, b) => {
          if (a.mobileOrder > b.mobileOrder) {
            return 1;
          }

          if (a.mobileOrder === b.mobileOrder) {
            return 0;
          }

          return -1;
        });
    }

    return [];
  }

  ngOnInit() {
    this.scrollDispatcher
      .scrolled()
      .pipe(map((event: CdkScrollable) => this.getScrollPosition(event)))
      .subscribe(scrollTop =>
        this.ngZone.run(
          () =>
            (this.shrinkToolbar =
              scrollTop > this.SHRINK_TOP_SCROLL_POSITION ? true : false)
        )
      );
  }

  getScrollPosition(event) {
    if (event) {
      return event.getElementRef().nativeElement.scrollTop;
    } else {
      return window.scrollY;
    }
  }

  onSideBarToggle() {
    this.toggle = !this.toggle;
    this.toggleSideBar.emit(this.toggle);
  }
}
