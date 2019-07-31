import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { DefaultLayoutComponent } from "./default-layout.component";
import { DefaultRoutingModule } from "../../routes/default-routing.module";

@NgModule({
  declarations: [DefaultLayoutComponent],
  imports: [CommonModule, DefaultRoutingModule],
  exports: [DefaultLayoutComponent]
})
export class DefaultLayoutModule {}
