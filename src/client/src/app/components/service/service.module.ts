import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ServiceComponent } from "./service.component";
import { FlexLayoutModule } from "@angular/flex-layout";
import { MatButtonModule } from "@angular/material";

@NgModule({
  declarations: [ServiceComponent],
  imports: [CommonModule, MatButtonModule, FlexLayoutModule],
  exports: [ServiceComponent]
})
export class ServiceModule {}
