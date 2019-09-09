import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { DefaultLayoutComponent } from "./default-layout.component";
import { HeaderModule } from "../../pages/shared/header/header.module";
import { SideBarModule } from "../../pages/shared/side-bar/side-bar.module";
import { MatSidenavModule } from "@angular/material/sidenav";
import { FooterModule } from "../../pages/shared/footer/footer.module";
import { RouterModule } from "@angular/router";
import { SettingService } from "src/app/cores/services/setting.service";

@NgModule({
  declarations: [DefaultLayoutComponent],
  imports: [
    CommonModule,
    HeaderModule,
    FooterModule,
    SideBarModule,
    MatSidenavModule,
    RouterModule
  ],
  exports: [DefaultLayoutComponent],
  providers: [SettingService]
})
export class DefaultLayoutModule {}
