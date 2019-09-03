import { Injectable } from "@angular/core";
import { MethodService } from "src/app/cores/services/method.service";
import { Method } from "src/app/cores/models/method.model";

export const METHOD = {
  CLEAN: 1,
  SOFT: 2,
  DRY: 3,
  STRAIGHT: 4
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
}
