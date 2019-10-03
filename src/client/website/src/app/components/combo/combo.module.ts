import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FlexLayoutModule } from "@angular/flex-layout";
import { ComboComponent } from "./combo.component";
import { KConverterPipe } from "src/app/cores/pipes/k.pipe";
import { MoneyConvertModule } from "../../cores/money-convert.module";
import { MatButtonModule } from "@angular/material/button";
import { MatIconModule } from "@angular/material/icon";
import { MatCardModule } from "@angular/material/card";

@NgModule({
  declarations: [ComboComponent],
  imports: [
    CommonModule,
    MatButtonModule,
    FlexLayoutModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MoneyConvertModule
  ],
  exports: [ComboComponent]
})
export class ComboModule {}
