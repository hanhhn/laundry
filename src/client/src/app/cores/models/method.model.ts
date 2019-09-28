export class Method {
  id: number;
  name: string;
  description: string;
  sortOrder: number;
  type: string;
  unit: string;
  rate: number;
  tax: number;
  discountRate: number;
  discount: number;
  enableDiscount: boolean;
  fullName: string;

  constructor(json: any) {
    this.id = json.id;
    this.name = json.name;
    this.description = json.description;
    this.enableDiscount = json.enableDiscount;
    this.sortOrder = json.sortOrder;
    this.unit = json.unit;
    this.type = json.type;
    this.rate = json.rate;
    this.tax = json.tax;
    this.discountRate = json.discountRate;
    this.discount = json.discount;
    this.fullName = json.fullName;
  }
}

export class MethodRequest {
  id: number;
  name: string;
  description: string;
  sortOrder: number;
  enableDiscount: boolean;
  type: string;
  unit: string;
}
