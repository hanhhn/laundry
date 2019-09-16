import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Routes, RouterModule } from "@angular/router";
import { DialogModule } from "primeng/dialog";
import { FileUploadModule } from "primeng/fileupload";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { DropdownModule } from "primeng/components/dropdown/dropdown";
import { PostService } from "src/app/cores/services/post.service";
import { ImageService } from "src/app/cores/services/image.service";
import { PageComponent } from "./page.component";
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
    component: PageComponent
  }
];

@NgModule({
  declarations: [PageComponent],
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
  exports: [PageComponent]
})
export class PostModule {}
