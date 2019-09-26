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
import { MatButtonModule } from "@angular/material/button";
import { MatInputModule } from "@angular/material/input";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatTableModule } from "@angular/material/table";
import { MatIconModule } from "@angular/material/icon";

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
