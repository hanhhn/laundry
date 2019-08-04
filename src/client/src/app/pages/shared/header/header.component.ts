import { Component, OnInit, EventEmitter, Output, NgZone } from "@angular/core";
import { ScrollDispatcher, CdkScrollable } from "@angular/cdk/overlay";
import { map } from "rxjs/operators";

@Component({
  selector: "app-header",
  templateUrl: "./header.component.html",
  styleUrls: ["./header.component.scss"]
})
export class HeaderComponent implements OnInit {
  desktopLinks = [
    { path: "ve-chung-toi", label: "Về chúng tôi" },
    { path: "dich-vu-va-quy-trinh", label: "Dịch vụ" },
    { path: "bang-gia", label: "Bảng giá" },
    { path: "lien-he", label: "Liên hệ" },
    { path: "dat-ngay", label: "Đặt ngay" }
  ];

  mobileLinks = [
    { path: "dat-ngay", label: "Đặt ngay" },
    { path: "bang-gia", label: "Bảng giá" },
    { path: "dich-vu-va-quy-trinh", label: "Dịch vụ" }
  ];

  @Output() toggleSideBar = new EventEmitter();
  toggle = false;

  private readonly SHRINK_TOP_SCROLL_POSITION = 15;
  shrinkToolbar = false;

  constructor(
    private scrollDispatcher: ScrollDispatcher,
    private ngZone: NgZone
  ) {}

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
