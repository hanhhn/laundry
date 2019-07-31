import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { FlexLayoutModule } from "@angular/flex-layout";
import { MatButtonModule } from "@angular/material/button";

const mCore = [BrowserModule, BrowserAnimationsModule, FlexLayoutModule];

const mComponent = [MatButtonModule];

@NgModule({
  imports: [...mCore, ...mComponent],
  exports: [...mCore, ...mComponent]
})
export class AppCoreModule {}
