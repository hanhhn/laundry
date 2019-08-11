import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { MatStepperModule } from "@angular/material/stepper";
import { BookNowComponent } from "./book-now.component";
import { MatFormFieldModule } from "@angular/material/form-field";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MatInputModule } from "@angular/material/input";
import { MatRadioModule } from "@angular/material/radio";
import { FlexLayoutModule } from "@angular/flex-layout";
import { ItemCheckModule } from "../../../components/item-check/item-check.module";
import {
  MatCheckboxModule,
  MatGridListModule,
  MatSelectChange,
  MatSelectModule
} from "@angular/material";

const routes: Routes = [
  {
    path: "",
    component: BookNowComponent
  }
];

@NgModule({
  declarations: [BookNowComponent],
  imports: [
    CommonModule,
    FormsModule,
    FlexLayoutModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    MatStepperModule,
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    MatRadioModule,
    MatCheckboxModule,
    ItemCheckModule,
    MatGridListModule,
    MatSelectModule,
    RouterModule.forChild(routes)
  ]
})
export class BookNowModule {}
