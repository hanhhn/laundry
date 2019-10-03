import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { BillComponent } from "./bill.component";

@NgModule({
  declarations: [BillComponent],
  imports: [CommonModule],
  exports: [BillComponent]
})
export class BillModule {}
