import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ServiceComponent } from "./service.component";
import { FlexLayoutModule } from "@angular/flex-layout";
import { RouterModule } from "@angular/router";
import { ComboModule } from "../combo/combo.module";
import { MatButtonModule } from "@angular/material/button";

@NgModule({
  declarations: [ServiceComponent],
  imports: [
    CommonModule,
    MatButtonModule,
    FlexLayoutModule,
    RouterModule,
    ComboModule
  ],
  exports: [ServiceComponent]
})
export class ServiceModule {}
