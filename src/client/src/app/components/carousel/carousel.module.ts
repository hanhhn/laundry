import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { CarouselComponent } from "./carousel.component";
import { MatButtonModule } from "@angular/material/button";
import { FlexLayoutModule } from "@angular/flex-layout";

@NgModule({
  declarations: [CarouselComponent],
  imports: [CommonModule, FlexLayoutModule, MatButtonModule],
  exports: [CarouselComponent]
})
export class CarouselModule {}
