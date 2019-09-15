import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Routes, RouterModule } from "@angular/router";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { SettingService } from "src/app/cores/services/setting.service";
import { FileUploadModule } from "primeng/fileupload";
import { ImageService } from "src/app/cores/services/image.service";
import { StepperComponent } from "./stepper.component";
import { PostService } from "../../../../cores/services/post.service";
import { DropdownModule } from "primeng/dropdown";

const routes: Routes = [
  {
    path: "",
    component: StepperComponent
  }
];
@NgModule({
  declarations: [StepperComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    FileUploadModule,
    DropdownModule,
    RouterModule.forChild(routes)
  ],
  providers: [SettingService, ImageService, PostService]
})
export class StepperModule {}
