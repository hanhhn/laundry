export class BillDetail {
  id: number;
  description: string;
  qty: number;
  rate: number;
  amount: number;

  constructor(json) {
    this.id = json.id;
    this.description = json.description;
    this.qty = json.qty;
    this.rate = json.rate;
    this.amount = json.amount;
  }
}

export class Bill {
  id: number;
  billCode: string;
  orderCode: string;
  phone: string;
  fullName: string;
  address: string;
  coupon: string;
  discount: number;
  amount: number;
  billAmount: number;
  createDate: Date;
  billDetails: BillDetail[];

  constructor(json) {
    this.id = json.id;
    this.billCode = json.billCode;
    this.orderCode = json.orderCode;
    this.phone = json.phone;
    this.fullName = json.fullName;
    this.address = json.address;
    this.coupon = json.coupon;
    this.discount = json.discount;
    this.amount = json.amount;
    this.billAmount = json.billAmount;
    this.createDate = json.createDate ? new Date(json.createDate) : null;
    this.billDetails = json.billDetails
      ? json.billDetails.map(x => new BillDetail(x))
      : [];
  }
}
