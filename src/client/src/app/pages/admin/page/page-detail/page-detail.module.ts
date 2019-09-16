import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Routes, RouterModule } from "@angular/router";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { DialogModule } from "primeng/dialog";
import { FileUploadModule } from "primeng/fileupload";
import { DropdownModule } from "primeng/dropdown";
import { CalendarModule } from "primeng/calendar";
import { PostService } from "src/app/cores/services/post.service";
import { ImageService } from "src/app/cores/services/image.service";
import { PageDetailComponent } from "./page-detail.component";
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
    component: PageDetailComponent
  }
];

@NgModule({
  declarations: [PageDetailComponent],
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
  exports: [PageDetailComponent]
})
export class PageDetailModule {}
