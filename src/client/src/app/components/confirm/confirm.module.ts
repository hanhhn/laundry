import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ConfirmComponent } from "./confirm.component";
import {
  MatButtonModule,
  MatDialogModule,
  MatCommonModule
} from "@angular/material";

@NgModule({
  declarations: [ConfirmComponent],
  entryComponents: [ConfirmComponent],
  imports: [CommonModule, MatButtonModule, MatDialogModule, MatCommonModule],
  exports: [ConfirmComponent]
})
export class ConfirmModule {}
