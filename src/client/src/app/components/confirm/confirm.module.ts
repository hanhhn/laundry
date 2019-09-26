import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ConfirmComponent } from "./confirm.component";
import { MatButtonModule } from "@angular/material/button";
import { MatDialogModule } from "@angular/material/dialog";
import { MatCommonModule } from "@angular/material/core";

@NgModule({
  declarations: [ConfirmComponent],
  entryComponents: [ConfirmComponent],
  imports: [CommonModule, MatButtonModule, MatDialogModule, MatCommonModule],
  exports: [ConfirmComponent]
})
export class ConfirmModule {}
