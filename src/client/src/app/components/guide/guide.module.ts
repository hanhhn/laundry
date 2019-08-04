import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { GuideComponent } from "./guide.component";
import { FlexLayoutModule } from "@angular/flex-layout";

@NgModule({
  declarations: [GuideComponent],
  imports: [CommonModule, FlexLayoutModule],
  exports: [GuideComponent]
})
export class GuideModule {}
