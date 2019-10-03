import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ServiceComponent } from "./service.component";
import { Routes, RouterModule } from "@angular/router";
import { DialogModule } from "primeng/dialog";
import { ItemService } from "../../../../cores/services/item.service";
import { MatButtonModule } from "@angular/material/button";
import { MatInputModule } from "@angular/material/input";
import { MatFormFieldModule } from "@angular/material/form-field";

const routes: Routes = [
  {
    path: "",
    component: ServiceComponent
  }
];

@NgModule({
  declarations: [ServiceComponent],
  imports: [
    CommonModule,
    MatButtonModule,
    DialogModule,
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    RouterModule.forChild(routes)
  ],
  providers: [ItemService],
  exports: [ServiceComponent]
})
export class ServiceModule {}
