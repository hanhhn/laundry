import { Component, OnInit, EventEmitter, Output, NgZone } from "@angular/core";
import { ScrollDispatcher, CdkScrollable } from "@angular/cdk/overlay";
import { map } from "rxjs/operators";

@Component({
  selector: "app-header",
  templateUrl: "./header.component.html",
  styleUrls: ["./header.component.scss"]
})
export class HeaderComponent implements OnInit {
  menuLinks = [
    {
      desktopOrder: 1,
      mobileOrder: 1,
      mobile: false,
      path: "ve-chung-toi",
      label: "Về chúng tôi"
    },
    {
      desktopOrder: 2,
      mobileOrder: 3,
      mobile: true,
      path: "dich-vu-va-quy-trinh",
      label: "Dịch vụ"
    },
    {
      desktopOrder: 3,
      mobileOrder: 2,
      mobile: true,
      path: "bang-gia",
      label: "Bảng giá"
    },
    {
      desktopOrder: 4,
      mobileOrder: 1,
      mobile: false,
      path: "lien-he",
      label: "Liên hệ"
    },
    {
      desktopOrder: 5,
      mobileOrder: 1,
      mobile: true,
      path: "dat-ngay",
      label: "Đặt ngay"
    }
  ];

  @Output() toggleSideBar = new EventEmitter();
  toggle = false;

  private readonly SHRINK_TOP_SCROLL_POSITION = 15;
  shrinkToolbar = false;

  constructor(
    private scrollDispatcher: ScrollDispatcher,
    private ngZone: NgZone
  ) {}

  get getLinkDesktop() {
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

  get getLinkMobile() {
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
