import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { SelectionComponent } from "./selection.component";
import { FlexLayoutModule } from "@angular/flex-layout";
import { MatButtonModule } from "@angular/material/button";
import { MatIconModule } from "@angular/material/icon";
import { MatCardModule } from "@angular/material/card";

@NgModule({
  declarations: [SelectionComponent],
  imports: [
    CommonModule,
    FlexLayoutModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule
  ],
  exports: [SelectionComponent]
})
export class SelectionModule {}
