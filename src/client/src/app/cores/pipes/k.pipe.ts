import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
  name: "kConverter"
})
export class KConverterPipe implements PipeTransform {
  transform(value: number): string {
    if (!value) {
      return "đang cập nhật";
    }

    return Math.round((value / 1000)) + "k";
  }
}
