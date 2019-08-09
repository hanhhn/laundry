import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ItemComponent } from "./item.component";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { MatCardModule } from "@angular/material/card";

@NgModule({
  declarations: [ItemComponent],
  imports: [CommonModule, MatCheckboxModule, MatCardModule],
  exports: [ItemComponent]
})
export class ItemModule {}
