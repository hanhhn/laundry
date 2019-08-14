import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ServiceItemComponent } from "./service-item.component";
import {
  MatButtonModule,
  MatIconModule,
  MatCardModule
} from "@angular/material";
import { FlexLayoutModule } from "@angular/flex-layout";

@NgModule({
  declarations: [ServiceItemComponent],
  imports: [
    CommonModule,
    MatButtonModule,
    FlexLayoutModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule
  ],
  exports: [ServiceItemComponent]
})
export class ServiceItemModule {}
