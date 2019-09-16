import { Jumbotron } from "./setting.model";

export class Item {
  id: number;
  image: string;
  name: string;
  description: string;
  highlight: boolean;
  sortOrder: number;
  type: number;
  typeName: string;
  rate: number;
  tax: number;
  discountRate: number;
  discount: number;
  methodId: number;
  methodName: number;
  methodDescription: string;

  constructor(json: any) {
    this.id = json.id;
    this.image = json.image;
    this.name = json.name;
    this.description = json.description;
    this.highlight = json.highlight;
    this.sortOrder = json.sortOrder;
    this.type = json.type;
    this.typeName = json.typeName;
    this.rate = json.rate;
    this.tax = json.tax;
    this.discountRate = json.discountRate;
    this.discount = json.discount;
    this.methodId = json.methodId;
    this.methodName = json.methodName;
    this.methodDescription = json.methodDescription;
  }
}

export class ItemRequest {
  id: string;
  image: string;
  name: string;
  type: number;
  description: string;
  highlight: boolean;
  sortOrder: number;
  methodId: number;
}

export class ItemCombo extends Jumbotron {
  items: Item[];

  constructor(json) {
    super(json);
    this.items = json.items ? json.items : [];
  }
}
