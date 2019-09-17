import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FlexLayoutModule } from "@angular/flex-layout";
import { PriceItemComponent } from "./price-item.component";

@NgModule({
  declarations: [PriceItemComponent],
  imports: [CommonModule, FlexLayoutModule],
  exports: [PriceItemComponent]
})
export class PriceItemModule {}
