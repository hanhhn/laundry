import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { DefaultLayoutComponent } from "./default-layout.component";
import { HeaderModule } from "src/app/pages/shared/header/header.module";
import { FooterModule } from "src/app/pages/shared/footer/footer.module";
import { DefaultModule } from "src/app/pages/default/default.module";

@NgModule({
  declarations: [DefaultLayoutComponent],
  imports: [CommonModule, HeaderModule, FooterModule, DefaultModule]
})
export class DefaultLayoutModule {}
