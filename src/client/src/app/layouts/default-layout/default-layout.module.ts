import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { DefaultModule } from "src/app/pages/default/default.module";
import { DefaultLayoutComponent } from "./default-layout.component";
import { FooterComponent } from "../../pages/shared/footer/footer.component";
import { HeaderModule } from "../../pages/shared/header/header.module";
import { SideBarModule } from "../../pages/shared/side-bar/side-bar.module";
import { MatSidenavModule } from "@angular/material/sidenav";

@NgModule({
  declarations: [DefaultLayoutComponent, FooterComponent],
  imports: [
    CommonModule,
    DefaultModule,
    HeaderModule,
    SideBarModule,
    MatSidenavModule
  ]
})
export class DefaultLayoutModule {}
