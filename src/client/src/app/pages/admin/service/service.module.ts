import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ServiceComponent } from "./service.component";
import { Routes, RouterModule } from "@angular/router";

const routes: Routes = [
  {
    path: "",
    component: ServiceComponent
  }
];

@NgModule({
  declarations: [ServiceComponent],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [ServiceComponent]
})
export class ServiceModule {}
