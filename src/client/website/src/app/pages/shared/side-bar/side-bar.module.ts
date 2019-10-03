import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { SideBarComponent } from "./side-bar.component";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatListModule } from "@angular/material/list";
import { RouterModule } from "@angular/router";

@NgModule({
  declarations: [SideBarComponent],
  imports: [
    CommonModule,
    RouterModule,
    MatToolbarModule,
    MatListModule
  ],
  exports: [SideBarComponent]
})
export class SideBarModule {}
