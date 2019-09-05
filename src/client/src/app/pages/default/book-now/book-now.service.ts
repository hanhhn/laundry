import { Injectable } from "@angular/core";
import { MethodService } from "src/app/cores/services/method.service";
import { Method } from "src/app/cores/models/method.model";
import { AddressUnit } from "src/app/cores/models/address.model";
import { AddressService } from "src/app/cores/services/address.service";

export const METHOD = {
  CLEAN: "Clean",
  SOFT: "Soft",
  DRY: "Dry",
  STRAIGHT: "Straight",
  DELIVERY: "Delivery"
};

@Injectable()
export class BookNowService {
  getCleanMethod(dataSource: Method[]): Method[] {
    return dataSource.filter(x => x.type === METHOD.CLEAN);
  }

  getSoftMethod(dataSource: Method[]): Method[] {
    return dataSource.filter(x => x.type === METHOD.SOFT);
  }

  getDryMethod(dataSource: Method[]): Method[] {
    return dataSource.filter(x => x.type === METHOD.DRY);
  }

  getStraightMethod(dataSource: Method[]): Method[] {
    return dataSource.filter(x => x.type === METHOD.STRAIGHT);
  }

  getDeliveryMethod(dataSource: Method[]): Method[] {
    return dataSource.filter(x => x.type === METHOD.DELIVERY);
  }
}
