import { Injectable } from "@angular/core";
import { HttpService } from "./http.service";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import { KeyValue } from "../models/object.model";
import { formatDate, paddingNumer } from "../helpers/utils.helper";

const DATE_FORMAT = "dd/MM/yyyy";

@Injectable()
export class TimeService {
  getActiveTime(): KeyValue[] {
    const today = new Date();
    const tomorrow = new Date();
    const dayaftertomorrow = new Date();
    tomorrow.setDate(today.getDate() + 1);
    dayaftertomorrow.setDate(today.getDate() + 2);

    return [
      new KeyValue(
        today,
        "Hôm nay (" +
          paddingNumer(today.getDate()) +
          "/" +
          paddingNumer(today.getMonth() + 1) +
          ")"
      ),
      new KeyValue(
        tomorrow,
        "Ngày mai (" +
          paddingNumer(tomorrow.getDate()) +
          "/" +
          paddingNumer(tomorrow.getMonth() + 1) +
          ")"
      ),
      new KeyValue(
        dayaftertomorrow,
        "Ngày kia (" +
          paddingNumer(dayaftertomorrow.getDate()) +
          "/" +
          paddingNumer(dayaftertomorrow.getMonth() + 1) +
          ")"
      )
    ];
  }
}
