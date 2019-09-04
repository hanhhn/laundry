import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ServiceComponent } from "./service.component";
import { Routes, RouterModule } from "@angular/router";
import {
  MatButtonModule,
  MatInputModule,
  MatFormFieldModule,
  MatTableModule,
  MatIconModule
} from "@angular/material";
import { DialogModule } from "primeng/dialog";
import { FileUploadModule } from "primeng/fileupload";
import { ItemService } from "../../../cores/services/item.service";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { ImageService } from "../../../cores/services/image.service";
import { DropdownModule } from "primeng/components/dropdown/dropdown";

const routes: Routes = [
  {
    path: "",
    component: ServiceComponent
  }
];

@NgModule({
  declarations: [ServiceComponent],
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
  providers: [ItemService, ImageService],
  exports: [ServiceComponent]
})
export class ServiceModule {}
