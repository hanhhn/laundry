export class Item {
  id: number;
  image: string;
  name: string;
  description: string;
  highlights: boolean;
  order: number;
  type: number;
  rate: number;
  tax: number;
  discountRate: number;
  discount: number;

  constructor(json: any) {
    this.id = json.id;
    this.image = json.image;
    this.name = json.name;
    this.description = json.description;
    this.highlights = json.highlights;
    this.order = json.order;
    this.type = json.type;
    this.rate = json.rate;
    this.tax = json.tax;
    this.discountRate = json.discountRate;
    this.discount = json.discount;
  }
}

export class ItemRate {
  id: number;
  itemId: number;
  itemName: string;
  rate: number;
  tax: number;
  discount: number;
  discountRate: number;
  priority: number;
  isActive: boolean;
  applyDate: Date;
  expireDate: Date;

  constructor(json: any) {
    this.id = json.id;
    this.itemId = json.itemId;
    this.rate = json.rate;
    this.tax = json.tax;
    this.discount = json.discount;
    this.discountRate = json.discountRate;
    this.priority = json.priority;
    this.isActive = json.isActive;
    this.applyDate = json.applyDate;
    this.expireDate = json.expireDate;
  }
}


export class ItemRequest {
  id: string;
  image: string;
  name: string;
  description: string;
  highlights: boolean;
  order: number;
}


export class ItemRateRequest {
  id: number;
  itemId: number;
  rate: number;
  tax: number;
  discount: number;
  priority: number;
  isActive: boolean;
  applyDate: Date;
  expireDate: Date;
}
