import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { AdminHeaderComponent } from "./admin-header.component";
import { MatToolbarModule } from "@angular/material/toolbar";

@NgModule({
  declarations: [AdminHeaderComponent],
  imports: [CommonModule, MatToolbarModule],
  exports: [AdminHeaderComponent]
})
export class AdminHeaderModule {}
