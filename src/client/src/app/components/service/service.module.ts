import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ServiceComponent } from "./service.component";
import { MatCardModule } from "@angular/material/card";
import { MatButtonModule } from "@angular/material/button";
import { FlexLayoutModule } from "@angular/flex-layout";
import { MatIconModule } from "@angular/material/icon";

@NgModule({
  declarations: [ServiceComponent],
  imports: [
    CommonModule,
    FlexLayoutModule,
    MatCardModule,
    MatButtonModule,
    MatIconModule
  ],
  exports: [ServiceComponent]
})
export class ServiceModule {}
