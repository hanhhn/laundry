import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { MatStepperModule } from "@angular/material/stepper";
import { BookNowComponent } from "./book-now.component";
import { MatFormFieldModule } from "@angular/material/form-field";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MatInputModule } from "@angular/material/input";
import { ItemModule } from "src/app/components/item/item.module";
import { FlexLayoutModule } from "@angular/flex-layout";

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
    ReactiveFormsModule,
    FlexLayoutModule,
    MatStepperModule,
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    ItemModule,
    RouterModule.forChild(routes)
  ]
})
export class BookNowModule {}
