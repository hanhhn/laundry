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
import { MatCheckboxModule, MatSelectModule } from "@angular/material";
import { VerticalStepperScrollerDirective } from "../../../cores/directives/vertical-stepper-scroller.directive";

const routes: Routes = [
  {
    path: "",
    component: BookNowComponent
  }
];

@NgModule({
  declarations: [BookNowComponent, VerticalStepperScrollerDirective],
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
    MatSelectModule,
    RouterModule.forChild(routes)
  ]
})
export class BookNowModule {}
