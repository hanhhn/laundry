export class Item {
  id: string;
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

export class ItemRequest {
  id: string;
  image: string;
  name: string;
  description: string;
  highlights: boolean;
  order: number;
}
