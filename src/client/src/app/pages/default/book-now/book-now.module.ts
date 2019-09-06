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
import {
  MatCheckboxModule,
  MatSelectModule,
  MatDialogModule
} from "@angular/material";
import { VerticalStepperScrollerDirective } from "../../../cores/directives/vertical-stepper-scroller.directive";
import { MethodService } from "../../../cores/services/method.service";
import { BookNowService } from "./book-now.service";
import { AddressService } from "src/app/cores/services/address.service";
import { ItemService } from "../../../cores/services/item.service";
import { TimeService } from "../../../cores/services/time.service";
import { ConfirmModule } from "src/app/components/confirm/confirm.module";

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
    MatDialogModule,
    ConfirmModule,
    RouterModule.forChild(routes)
  ],
  providers: [
    MethodService,
    BookNowService,
    AddressService,
    ItemService,
    TimeService
  ]
})
export class BookNowModule {}
