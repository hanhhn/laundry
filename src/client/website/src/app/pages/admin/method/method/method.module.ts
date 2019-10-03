import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { MethodComponent } from "./method.component";
import { DialogModule } from "primeng/dialog";
import { RouterModule, Routes } from "@angular/router";
import { MethodService } from "src/app/cores/services/method.service";

const routes: Routes = [
  {
    path: "",
    component: MethodComponent
  }
];

@NgModule({
  declarations: [MethodComponent],
  imports: [CommonModule, DialogModule, RouterModule.forChild(routes)],
  exports: [MethodComponent],
  providers: [MethodService]
})
export class MethodModule {}
