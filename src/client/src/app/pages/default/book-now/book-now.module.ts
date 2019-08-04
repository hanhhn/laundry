import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { MatStepperModule } from "@angular/material/stepper";
import { BookNowComponent } from "./book-now.component";
import { MatFormFieldModule } from "@angular/material/form-field";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatButtonModule } from "@angular/material/button";
import { MatInputModule } from "@angular/material/input";

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
    MatStepperModule,
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    RouterModule.forChild(routes)
  ]
})
export class BookNowModule {}
