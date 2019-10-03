import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { AboutComponent } from "./about.component";
import { SelectionModule } from "../../../components/selection/selection.module";

const routes: Routes = [
  {
    path: "",
    component: AboutComponent
  }
];

@NgModule({
  declarations: [AboutComponent],
  imports: [CommonModule, SelectionModule, RouterModule.forChild(routes)]
})
export class AboutModule {}
