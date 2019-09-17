import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FlexLayoutModule } from "@angular/flex-layout";
import { PriceItemComponent } from "./price-item.component";
import { KConverterPipe } from "../../cores/pipes/k.pipe";
import { MoneyConvertModule } from "../../cores/money-convert.module";

@NgModule({
  declarations: [PriceItemComponent],
  imports: [CommonModule, FlexLayoutModule, MoneyConvertModule],
  exports: [PriceItemComponent]
})
export class PriceItemModule {}
