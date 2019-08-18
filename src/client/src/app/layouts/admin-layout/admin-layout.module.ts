import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { AdminLayoutComponent } from "./admin-layout.component";
import { RouterModule, Routes } from "@angular/router";
import { AdminSideBarModule } from "../../pages/shared/admin-side-bar/admin-side-bar.module";
import { AdminHeaderModule } from "../../pages/shared/admin-header/admin-header.module";
import { MatSidenavModule } from "@angular/material";

@NgModule({
  declarations: [AdminLayoutComponent],
  imports: [
    CommonModule,
    RouterModule,
    AdminHeaderModule,
    AdminSideBarModule,
    MatSidenavModule,
    RouterModule
  ],
  exports: [AdminLayoutComponent]
})
export class AdminLayoutModule {}
