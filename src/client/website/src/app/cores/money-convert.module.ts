import { NgModule } from "@angular/core";
import { KConverterPipe } from "./pipes/k.pipe";

@NgModule({
  declarations: [KConverterPipe],
  exports: [KConverterPipe]
})
export class MoneyConvertModule {}
