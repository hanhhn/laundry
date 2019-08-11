import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ItemCheckComponent } from "./item-check.component";
import { MatCheckboxModule } from "@angular/material/checkbox";

@NgModule({
  declarations: [ItemCheckComponent],
  imports: [CommonModule, MatCheckboxModule],
  exports: [ItemCheckComponent]
})
export class ItemCheckModule {}
