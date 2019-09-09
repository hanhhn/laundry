import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { CompanyComponent } from "./company.component";
import { Routes, RouterModule } from "@angular/router";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { SettingService } from "src/app/cores/services/setting.service";
import { FileUploadModule } from "primeng/fileupload";
import { ImageService } from "src/app/cores/services/image.service";

const routes: Routes = [
  {
    path: "",
    component: CompanyComponent
  }
];
@NgModule({
  declarations: [CompanyComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    FileUploadModule,
    RouterModule.forChild(routes)
  ],
  providers: [SettingService, ImageService]
})
export class CompanyModule {}
