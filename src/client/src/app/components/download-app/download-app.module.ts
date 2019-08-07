import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { DownloadAppComponent } from "./download-app.component";
import { FlexLayoutModule } from "@angular/flex-layout";

@NgModule({
  declarations: [DownloadAppComponent],
  imports: [CommonModule, FlexLayoutModule],
  exports: [DownloadAppComponent]
})
export class DownloadAppModule {}
