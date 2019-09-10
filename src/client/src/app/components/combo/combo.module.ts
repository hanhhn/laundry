import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FlexLayoutModule } from "@angular/flex-layout";
import { ComboComponent } from "./combo.component";
import { KConverterPipe } from "src/app/cores/pipes/k.pipe";

import {
  MatButtonModule,
  MatIconModule,
  MatCardModule
} from "@angular/material";

@NgModule({
  declarations: [ComboComponent, KConverterPipe],
  imports: [
    CommonModule,
    MatButtonModule,
    FlexLayoutModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule
  ],
  exports: [ComboComponent]
})
export class ComboModule {}
