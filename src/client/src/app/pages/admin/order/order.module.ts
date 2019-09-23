import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { OrderComponent } from "./order.component";
import { Routes, RouterModule } from "@angular/router";
import { OrdersService } from "src/app/cores/services/orders.service";

const routes: Routes = [
  {
    path: "",
    component: OrderComponent
  }
];

@NgModule({
  declarations: [OrderComponent],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [OrderComponent],
  providers: [OrdersService]
})
export class OrderModule {}
