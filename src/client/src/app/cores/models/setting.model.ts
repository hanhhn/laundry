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

export class Company {
  name: string;
  address: string;
  phone: string;
  email: string;
  brand: string;
  logo: string;
  website: string;
  copyright: string;
  map: string;

  constructor(company: any) {
    if (company) {
      this.name = company.name;
      this.address = company.address;
      this.phone = company.phone;
      this.email = company.email;
      this.brand = company.brand;
      this.logo = company.logo;
      this.website = company.website;
      this.copyright = company.copyright;
      this.map = company.map;
    }
  }
}

export class Link {
  facebook: string;
  instagram: string;
  youtube: string;
  appStore: string;
  googlePlay: string;

  constructor(link: any) {
    if (link) {
      this.facebook = link.facebook;
      this.instagram = link.instagram;
      this.youtube = link.youtube;
      this.appStore = link.appStore;
      this.googlePlay = link.googlePlay;
    }
  }
}
