export class PriceRequest {
  id: number;
  itemId: number;
  itemCode: number;
  rate: number;
  tax: number;
  discount: number;
  priority: number;
  isActive: boolean;
  applyDate: Date;
  expireDate: Date;
}

export class Price {
  id: number;
  itemId: number;
  itemCode: number;
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
    this.itemCode = json.itemCode;
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
