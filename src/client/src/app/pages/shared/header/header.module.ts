import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HeaderComponent } from "./header.component";
import { FlexLayoutModule } from "@angular/flex-layout";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatMenuModule } from "@angular/material/menu";
import { MatButtonModule } from "@angular/material/button";
import { MatTabsModule } from "@angular/material/tabs";
import { RouterModule, Routes } from "@angular/router";
import { MatRippleModule } from "@angular/material/core";

@NgModule({
  declarations: [HeaderComponent],
  imports: [
    CommonModule,
    RouterModule,
    FlexLayoutModule,
    MatToolbarModule,
    MatMenuModule,
    MatButtonModule,
    MatRippleModule,
    MatTabsModule
  ],
  exports: [HeaderComponent]
})
export class HeaderModule {}
