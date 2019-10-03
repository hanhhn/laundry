import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { TrackingComponent } from "./tracking.component";
import { Routes, RouterModule } from "@angular/router";
import { TrackingService } from "src/app/cores/services/trackings.service";
import { FlexLayoutModule } from "@angular/flex-layout";
import { TrackingConverterPipe } from "src/app/cores/pipes/tracking.pipe";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatButtonModule } from "@angular/material/button";
import { MatInputModule } from "@angular/material/input";
import { MatTableModule } from "@angular/material/table";
import { MatStepperModule } from "@angular/material/stepper";

const routes: Routes = [
  {
    path: "",
    component: TrackingComponent
  }
];

@NgModule({
  declarations: [TrackingComponent, TrackingConverterPipe],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    MatTableModule,
    FlexLayoutModule,
    MatStepperModule,
    RouterModule.forChild(routes)
  ],
  providers: [TrackingService]
})
export class TrackingModule {}
