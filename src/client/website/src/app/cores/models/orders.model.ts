import { Method } from "./method.model";

export class OrderDetail {
  id: number;
  orderId: string;
  methodId: number;
  methodName: string;
  description: string;
  type: string;
  qty: number;

  constructor(json) {
    this.id = json.id;
    this.orderId = json.orderId;
    this.methodId = json.methodId;
    this.methodName = json.methodName;
    this.description = json.description;
    this.type = json.type;
    this.qty = json.qty;
  }
}

export class Order {
  id: number;
  orderCode: string;
  phone: string;
  fullName: string;
  provinceName: number;
  districtName: number;
  wardName: number;
  street: number;
  dateOfReceipt: Date;
  hoursOfReceipt: string;
  note: string;
  fullAddress: string;
  orderDetails: OrderDetail[];
  billId: number;

  constructor(json) {
    this.id = json.id;
    this.orderCode = json.orderCode;
    this.phone = json.phone;
    this.fullName = json.fullName;
    this.provinceName = json.provinceName;
    this.districtName = json.districtName;
    this.wardName = json.wardName;
    this.street = json.street;
    this.dateOfReceipt = json.dateOfReceipt;
    this.hoursOfReceipt = json.hoursOfReceipt;
    this.note = json.note;
    this.fullAddress = json.fullAddress;
    this.orderDetails = json.orderDetails
      ? json.orderDetails.map(x => new OrderDetail(x))
      : [];
    this.billId = json.billId;
  }

  get getTrackingUrl(): string {
    return "order/tracking?phone=" + this.phone + "&code=" + this.orderCode;
  }
}

export class OrderRequest {
  cleanId: number;
  optionsId: number[];
  deliveryId: number;
  addressId: string;
  phone: string;
  fullName: string;
  provinceId: number;
  districtId: number;
  wardId: number;
  street: number;
  dateOfReceipt: string;
  hoursOfReceipt: string;
  note: string;
}

export class Detail {
  methodId: number;
  qty: number;
}

export class OrderDetailRequest {
  orderId: string;
  details: Detail[];
  note: string;

  constructor() {
    this.details = [];
  }
}

export class Tracking {
  id: number;
  orderCode: string;
  orderStatus: number;
  status: string;

  constructor(json) {
    this.id = json.id;
    this.orderCode = this.orderCode;
    this.orderCode = this.orderCode;
    this.status = this.status;
  }
}

export class OrderHistory {
  orderCode: string;
  purchaseDate: Date;
  services: Method[];
  orderStatus: Tracking[];
  amount: number;
  paymentStatus: number;
  dateOfReceipt: string;
  hoursOfReceipt: string;
  payment: string;
  fullAddress: string;

  constructor(json) {
    this.orderCode = json.orderCode;
    this.purchaseDate = json.purchaseDate;
    this.services = json.services ? json.services.map(x => new Method(x)) : [];
    this.orderStatus = json.orderStatus
      ? json.orderStatus.map(x => new Tracking(x))
      : [];
    this.amount = json.amount;
    this.paymentStatus = json.paymentStatus;
    this.orderStatus = json.orderStatus;
    this.payment = json.payment;
    this.dateOfReceipt = json.dateOfReceipt;
    this.hoursOfReceipt = json.hoursOfReceipt;
    this.fullAddress = json.fullAddress;
  }
}

export class OrderFilter {
  orderCode: string;
  phone: string;
  fullName: string;
  keyword: string;
}
