import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FlexLayoutModule } from "@angular/flex-layout";
import { FooterComponent } from "./footer.component";
import { FacebookModule } from "ngx-facebook";

@NgModule({
  declarations: [FooterComponent],
  imports: [CommonModule, FlexLayoutModule, FacebookModule.forRoot()],
  exports: [FooterComponent]
})
export class FooterModule {}
