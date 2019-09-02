import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { PriceListComponent } from "./price-list.component";
import { Routes, RouterModule } from "@angular/router";
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import {
  MatButtonModule,
  MatInputModule,
  MatFormFieldModule,
  MatTableModule,
  MatIconModule
} from "@angular/material";
import { DialogModule } from "primeng/dialog";
import { FileUploadModule } from "primeng/fileupload";
import { ConfirmDialogModule } from "primeng/confirmdialog";
import { ItemService } from "../../../cores/services/item.service";
import { ConfirmationService } from "primeng/api";
import { ItemRateService } from "../../../cores/services/item-rate.service";
import { DropdownModule } from "primeng/dropdown";
import { CalendarModule } from "primeng/calendar";

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
    ConfirmDialogModule,
    DropdownModule,
    CalendarModule,
    RouterModule.forChild(routes)
  ],
  providers: [ItemService, ItemRateService, ConfirmationService],
  exports: [PriceListComponent]
})
export class PriceListModule {}
