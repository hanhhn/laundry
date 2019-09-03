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
