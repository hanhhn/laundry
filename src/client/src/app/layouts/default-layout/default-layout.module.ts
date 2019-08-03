import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { DefaultModule } from "src/app/pages/default/default.module";
import { MatSidenavModule } from "@angular/material/sidenav";
import { DefaultLayoutComponent } from "./default-layout.component";
import { FooterComponent } from "../../pages/shared/footer/footer.component";
import { SideBarComponent } from "../../pages/shared/side-bar/side-bar.component";
import { HeaderModule } from "../../pages/shared/header/header.module";

@NgModule({
  declarations: [DefaultLayoutComponent, FooterComponent, SideBarComponent],
  imports: [CommonModule, DefaultModule, HeaderModule, MatSidenavModule]
})
export class DefaultLayoutModule {}
