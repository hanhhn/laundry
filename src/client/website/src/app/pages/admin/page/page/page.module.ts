import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Routes, RouterModule } from "@angular/router";
import { DialogModule } from "primeng/dialog";
import { FileUploadModule } from "primeng/fileupload";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { DropdownModule } from "primeng/components/dropdown/dropdown";
import { PageService } from "../../../../cores/services/page.service";
import { ImageService } from "src/app/cores/services/image.service";
import { PageComponent } from "./page.component";
import { MatButtonModule } from "@angular/material/button";
import { MatInputModule } from "@angular/material/input";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatTableModule } from "@angular/material/table";
import { MatIconModule } from "@angular/material/icon";

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
  providers: [PageService, ImageService],
  exports: [PageComponent]
})
export class PageModule {}
