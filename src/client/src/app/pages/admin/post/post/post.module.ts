import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { PostComponent } from "./post.component";
import { Routes, RouterModule } from "@angular/router";
import { DialogModule } from "primeng/dialog";
import { FileUploadModule } from "primeng/fileupload";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { DropdownModule } from "primeng/components/dropdown/dropdown";
import { PostService } from "src/app/cores/services/post.service";
import { ImageService } from "src/app/cores/services/image.service";
import {
  MatButtonModule,
  MatInputModule,
  MatFormFieldModule,
  MatTableModule,
  MatIconModule
} from "@angular/material";

const routes: Routes = [
  {
    path: "",
    component: PostComponent
  }
];

@NgModule({
  declarations: [PostComponent],
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
    RouterModule.forChild(routes)
  ],
  providers: [PostService, ImageService],
  exports: [PostComponent]
})
export class PostModule {}
