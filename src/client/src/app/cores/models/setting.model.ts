export class Menu {
  label: string;
  url: string;
  mobile: boolean;
  mobileOrder: number;
  desktopOrder: number;

  constructor(menu: any) {
    if (menu) {
      this.label = menu.label;
      this.url = menu.url;
      this.mobile = menu.mobile;
      this.mobileOrder = menu.mobileOrder;
      this.desktopOrder = menu.desktopOrder;
    }
  }

  toJson() {
    return {
      label: this.label,
      url: this.url,
      mobile: this.mobile,
      mobileOrder: this.mobileOrder,
      desktopOrder: this.desktopOrder
    };
  }
}
