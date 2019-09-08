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

  method: string;
  soft: string;
  straight: string;

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
  }

  get getTrackingUrl(): string {
    return "order/tracking?phone=" + this.phone + "&code=" + this.orderCode;
  }
}

export class OrderRequest {
  methodId: number;
  softId: number;
  straightId: number;
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
