import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ServiceListComponent } from "./service-list.component";
import { FlexLayoutModule } from "@angular/flex-layout";
import { ServiceItemModule } from "../service-item/service-item.module";

@NgModule({
  declarations: [ServiceListComponent],
  imports: [CommonModule, FlexLayoutModule, ServiceItemModule],
  exports: [ServiceListComponent]
})
export class ServiceListModule {}
