export class AddressUnit {
  id: number;
  name: string;
  prefix: string;
  fullName: string;

  constructor(json) {
    this.id = json.id;
    this.name = json.name;
    this.prefix = json.prefix;
    this.fullName = json.fullName;
  }
}

export class Address {
  id: number;
  phone: string;
  fullName: string;
  isDefault: string;
  proviceId: number;
  provice: string;
  districtId: number;
  district: string;
  wardId: number;
  ward: string;
  street: string;

  constructor(json) {
    this.id = json.id;
    this.phone = json.phone;
    this.fullName = json.fullName;
    this.isDefault = json.isDefault;
    this.proviceId = json.proviceId;
    this.provice = json.provice;
    this.districtId = json.districtId;
    this.district = json.district;
    this.wardId = json.wardId;
    this.ward = json.ward;
    this.street = json.wardId;
  }
}

export class AddressRequest {
  id: number;
  phone: string;
  fullName: string;
  isDefault: string;
  proviceId: number;
  districtId: number;
  wardId: number;
  street: string;
}
