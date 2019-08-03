import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { DefaultModule } from "src/app/pages/default/default.module";
import { MatSidenavModule } from "@angular/material/sidenav";
import { DefaultLayoutComponent } from "./default-layout.component";
import { FooterComponent } from "../../pages/shared/footer/footer.component";
import { HeaderComponent } from "../../pages/shared/header/header.component";
import { SideNavComponent } from "../../pages/shared/side-nav/side-nav.component";

@NgModule({
  declarations: [
    DefaultLayoutComponent,
    HeaderComponent,
    FooterComponent,
    SideNavComponent
  ],
  imports: [CommonModule, DefaultModule, MatSidenavModule]
})
export class DefaultLayoutModule {}
