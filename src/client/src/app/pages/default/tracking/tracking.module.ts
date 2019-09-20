import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { TrackingComponent } from "./tracking.component";
import { Routes, RouterModule } from "@angular/router";
import { TrackingService } from "src/app/cores/services/trackings.service";
import { MatTableModule } from "@angular/material";

const routes: Routes = [
  {
    path: "",
    component: TrackingComponent
  }
];

@NgModule({
  declarations: [TrackingComponent],
  imports: [CommonModule, MatTableModule, RouterModule.forChild(routes)],
  providers: [TrackingService]
})
export class TrackingModule {}
