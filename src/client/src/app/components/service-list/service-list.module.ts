import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ServiceListComponent } from "./service-list.component";
import { FlexLayoutModule } from "@angular/flex-layout";
import { ComboModule } from "../combo/combo.module";

@NgModule({
  declarations: [ServiceListComponent],
  imports: [CommonModule, FlexLayoutModule, ComboModule],
  exports: [ServiceListComponent]
})
export class ServiceListModule {}
