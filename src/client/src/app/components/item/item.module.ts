import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ItemComponent } from "./item.component";
import { MoneyConvertModule } from "../../cores/money-convert.module";

@NgModule({
  declarations: [ItemComponent],
  imports: [CommonModule, MoneyConvertModule],
  exports: [ItemComponent]
})
export class ItemModule {}
