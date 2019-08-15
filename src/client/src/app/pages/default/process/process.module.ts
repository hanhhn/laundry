import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { ProcessComponent } from "./process.component";
import { WorkFollowModule } from "../../../components/work-follow/work-follow.module";

const routes: Routes = [
  {
    path: "",
    component: ProcessComponent
  }
];

@NgModule({
  declarations: [ProcessComponent],
  imports: [CommonModule, WorkFollowModule, RouterModule.forChild(routes)]
})
export class ProcessModule {}
