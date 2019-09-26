import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { AdminSideBarComponent } from "./admin-side-bar.component";
import { RouterModule } from "@angular/router";
import { MenuModule } from "primeng/menu";
import { MatListModule } from "@angular/material/list";
import { MatToolbarModule } from "@angular/material/toolbar";

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
