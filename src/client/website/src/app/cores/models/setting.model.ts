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
  facebook: string;
  instagram: string;
  youtube: string;
  appStore: string;
  googlePlay: string;
  googleMap: string;

  constructor(json: any) {
    if (json) {
      this.name = json.name;
      this.address = json.address;
      this.phone = json.phone;
      this.email = json.email;
      this.brand = json.brand;
      this.logo = json.logo;
      this.website = json.website;
      this.copyright = json.copyright;
      this.facebook = json.facebook;
      this.instagram = json.instagram;
      this.youtube = json.youtube;
      this.appStore = json.appStore;
      this.googlePlay = json.googlePlay;
      this.googleMap = json.googleMap;
    }
  }
}

export class Reason {
  title: string;
  image: string;
  description: string;
  reasons: string[];

  constructor(json: any) {
    this.title = json.title;
    this.image = json.image;
    this.description = json.description;
    this.reasons = json.reasons ? json.reasons : [];
  }
}

export class Jumbotron {
  background: string;
  title: string;
  description: string;
  firstButton: string;
  firstLink: string;
  secondButton: string;
  secondLink: string;

  constructor(json: any) {
    this.background = json.background;
    this.title = json.title;
    this.description = json.description;
    this.firstButton = json.firstButton;
    this.firstLink = json.firstLink;
    this.secondButton = json.secondButton;
    this.secondLink = json.secondLink;
  }
}

export class Guide {
  image: string;
  title: string;
  description: string;
  steppers: any;

  constructor(json: any) {
    this.image = json.image;
    this.title = json.title;
    this.description = json.description;
    this.steppers = json.steppers;
  }
}
