import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Routes, RouterModule } from "@angular/router";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { SettingService } from "src/app/cores/services/setting.service";
import { FileUploadModule } from "primeng/fileupload";
import { ImageService } from "src/app/cores/services/image.service";
import { ComboComponent } from "./combo.component";

const routes: Routes = [
  {
    path: "",
    component: ComboComponent
  }
];
@NgModule({
  declarations: [ComboComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    FileUploadModule,
    RouterModule.forChild(routes)
  ],
  providers: [SettingService, ImageService]
})
export class ComboModule {}
