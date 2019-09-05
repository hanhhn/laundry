export class Method {
  id: number;
  name: string;
  description: string;
  discount: string;
  enableDiscount: boolean;
  type: string;

  constructor(json) {
    this.id = json.id;
    this.name = json.name;
    this.description = json.description;
    this.discount = json.discount;
    this.enableDiscount = json.enableDiscount;
    this.type = json.type;
  }
}

export class MethodRequest {
  id: number;
  name: string;
  description: string;
  discount: string;
  enableDiscount: boolean;
  type: string;
}
