import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { ProcessComponent } from "./process.component";
import { PostListModule } from "../../../components/post-list/post-list.module";

const routes: Routes = [
  {
    path: "",
    component: ProcessComponent
  }
];

@NgModule({
  declarations: [ProcessComponent],
  imports: [CommonModule, PostListModule, RouterModule.forChild(routes)]
})
export class ProcessModule {}
