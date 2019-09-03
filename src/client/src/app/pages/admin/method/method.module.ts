import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { MethodComponent } from "./method.component";
import { MethodService } from "../../../cores/services/method.service";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { DialogModule } from "primeng/dialog";
import { FileUploadModule } from "primeng/fileupload";
import { DropdownModule } from "primeng/dropdown";
import { CalendarModule } from "primeng/calendar";
import { RouterModule, Routes } from "@angular/router";
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
    component: MethodComponent
  }
];

@NgModule({
  declarations: [MethodComponent],
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
  exports: [MethodComponent],
  providers: [MethodService]
})
export class MethodModule {}
