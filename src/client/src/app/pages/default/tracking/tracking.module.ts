import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { TrackingComponent } from "./tracking.component";
import { Routes, RouterModule } from "@angular/router";
import { TrackingService } from "src/app/cores/services/trackings.service";
import {
  MatTableModule,
  MatFormFieldModule,
  MatButtonModule,
  MatInputModule
} from "@angular/material";
import { FlexLayoutModule } from "@angular/flex-layout";
import { TrackingConverterPipe } from "src/app/cores/pipes/tracking.pipe";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";

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
    RouterModule.forChild(routes)
  ],
  providers: [TrackingService]
})
export class TrackingModule {}
