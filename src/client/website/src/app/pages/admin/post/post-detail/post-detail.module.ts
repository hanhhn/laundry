import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Routes, RouterModule } from "@angular/router";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { DialogModule } from "primeng/dialog";
import { FileUploadModule } from "primeng/fileupload";
import { DropdownModule } from "primeng/dropdown";
import { CalendarModule } from "primeng/calendar";
import { PostDetailComponent } from "./post-detail.component";
import { PostService } from "src/app/cores/services/post.service";
import { ImageService } from "src/app/cores/services/image.service";
import { MatButtonModule } from "@angular/material/button";
import { MatInputModule } from "@angular/material/input";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatTableModule } from "@angular/material/table";
import { MatIconModule } from "@angular/material/icon";

const routes: Routes = [
  {
    path: "",
    component: PostDetailComponent
  }
];

@NgModule({
  declarations: [PostDetailComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    MatTableModule,
    MatIconModule,
    DialogModule,
    FileUploadModule,
    DropdownModule,
    CalendarModule,
    RouterModule.forChild(routes)
  ],
  providers: [PostService, ImageService],
  exports: [PostDetailComponent]
})
export class PostDetailModule {}
