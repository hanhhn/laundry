import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { SelectionComponent } from "./selection.component";
import { FlexLayoutModule } from "@angular/flex-layout";

@NgModule({
  declarations: [SelectionComponent],
  imports: [CommonModule, FlexLayoutModule],
  exports: [SelectionComponent]
})
export class SelectionModule {}
