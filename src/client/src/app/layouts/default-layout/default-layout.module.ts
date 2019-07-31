import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { DefaultLayoutComponent } from "./default-layout.component";

@NgModule({
  declarations: [DefaultLayoutComponent],
  imports: [CommonModule],
  exports: [DefaultLayoutComponent]
})
export class DefaultLayoutModule {}
