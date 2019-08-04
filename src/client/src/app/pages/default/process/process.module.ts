import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { ProcessComponent } from "./process.component";

const routes: Routes = [
  {
    path: "",
    component: ProcessComponent
  }
];

@NgModule({
  declarations: [ProcessComponent],
  imports: [CommonModule, RouterModule.forChild(routes)]
})
export class ProcessModule {}
