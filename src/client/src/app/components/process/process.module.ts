import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ProcessComponent } from "./process.component";
import { FlexLayoutModule } from "@angular/flex-layout";

@NgModule({
  declarations: [ProcessComponent],
  imports: [CommonModule, FlexLayoutModule],
  exports: [ProcessComponent]
})
export class ProcessModule {}
