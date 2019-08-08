import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { DefaultModule } from "src/app/pages/default/default.module";
import { DefaultLayoutComponent } from "./default-layout.component";
import { HeaderModule } from "../../pages/shared/header/header.module";
import { SideBarModule } from "../../pages/shared/side-bar/side-bar.module";
import { MatSidenavModule } from "@angular/material/sidenav";
import { FooterModule } from "../../pages/shared/footer/footer.module";

@NgModule({
  declarations: [DefaultLayoutComponent],
  imports: [
    CommonModule,
    DefaultModule,
    HeaderModule,
    FooterModule,
    SideBarModule,
    MatSidenavModule
  ]
})
export class DefaultLayoutModule {}
