import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { PriceListComponent } from "./price-list.component";
import { Routes, RouterModule } from "@angular/router";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { DialogModule } from "primeng/dialog";
import { FileUploadModule } from "primeng/fileupload";
import { ItemService } from "../../../cores/services/item.service";
import { DropdownModule } from "primeng/dropdown";
import { CalendarModule } from "primeng/calendar";
import {
  MatButtonModule,
  MatInputModule,
  MatFormFieldModule,
  MatTableModule,
  MatIconModule
} from "@angular/material";
import { PriceService } from "src/app/cores/services/price.service";
import { MethodService } from "src/app/cores/services/method.service";

const routes: Routes = [
  {
    path: "",
    component: PriceListComponent
  }
];

@NgModule({
  declarations: [PriceListComponent],
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
  providers: [ItemService, PriceService, MethodService],
  exports: [PriceListComponent]
})
export class PriceListModule {}
