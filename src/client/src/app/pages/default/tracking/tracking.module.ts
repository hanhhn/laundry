import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { TrackingComponent } from "./tracking.component";
import { Routes, RouterModule } from "@angular/router";

const routes: Routes = [
  {
    path: "",
    component: TrackingComponent
  }
];

@NgModule({
  declarations: [TrackingComponent],
  imports: [CommonModule, RouterModule.forChild(routes)]
})
export class TrackingModule {}
