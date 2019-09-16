import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Routes, RouterModule } from "@angular/router";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { DialogModule } from "primeng/dialog";
import { FileUploadModule } from "primeng/fileupload";
import { DropdownModule } from "primeng/dropdown";
import {
  MatButtonModule,
  MatInputModule,
  MatFormFieldModule,
  MatTableModule,
  MatIconModule
} from "@angular/material";
import { ImageService } from "src/app/cores/services/image.service";
import { MethodService } from "../../../../cores/services/method.service";
import { ItemService } from "../../../../cores/services/item.service";
import { ServiceDetailComponent } from "./service-detail.component";

const routes: Routes = [
  {
    path: "",
    component: ServiceDetailComponent
  }
];

@NgModule({
  declarations: [ServiceDetailComponent],
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
  providers: [ItemService, ImageService, MethodService],
  exports: [ServiceDetailComponent]
})
export class ServiceDetailModule {}
