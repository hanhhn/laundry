import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { MatButtonModule } from "@angular/material/button";
import { FlexLayoutModule } from "@angular/flex-layout";
import { RouterModule } from "@angular/router";
import { JumbotronComponent } from "./jumbotron.component";

@NgModule({
  declarations: [JumbotronComponent],
  imports: [CommonModule, FlexLayoutModule, MatButtonModule, RouterModule],
  exports: [JumbotronComponent]
})
export class JumbotronModule {}
