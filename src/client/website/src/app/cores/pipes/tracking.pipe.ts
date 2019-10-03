import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
  name: "trackConverter"
})
export class TrackingConverterPipe implements PipeTransform {
  transform(value: string): string {
    switch (value) {
      case "Receive":
        return value + " - " + "Đã tiếp nhận đơn hàng.";
      case "Laundry":
        return value + " - " + "Đang giặt.";
      case "Delivery":
        return value + " - " + "Đang giao hàng.";
      case "Success":
        return value + " - " + "Giao hàng thành công.";
      case "Cancel":
        return value + " - " + "Đơn hàng đã hủy.";
    }
  }
}
