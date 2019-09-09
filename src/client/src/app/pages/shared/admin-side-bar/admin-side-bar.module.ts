import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { AdminSideBarComponent } from "./admin-side-bar.component";
import { RouterModule } from "@angular/router";
import { MatToolbarModule, MatListModule } from "@angular/material";
import { MenuModule } from "primeng/menu";

@NgModule({
  declarations: [AdminSideBarComponent],
  imports: [
    CommonModule,
    RouterModule,
    MatListModule,
    MatToolbarModule,
    MenuModule
  ],
  exports: [AdminSideBarComponent]
})
export class AdminSideBarModule {}
