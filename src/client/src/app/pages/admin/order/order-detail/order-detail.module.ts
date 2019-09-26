import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { Routes, RouterModule } from "@angular/router";
import { OrdersService } from "src/app/cores/services/orders.service";
import { PaginatorModule } from "primeng/paginator";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { DialogModule } from "primeng/dialog";
import { DropdownModule } from "primeng/dropdown";
import { OrderDetailComponent } from "./order-detail.component";
import { MethodService } from "src/app/cores/services/method.service";

const routes: Routes = [
  {
    path: "",
    component: OrderDetailComponent
  }
];

@NgModule({
  declarations: [OrderDetailComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    DialogModule,
    DropdownModule,
    PaginatorModule,
    RouterModule.forChild(routes)
  ],
  exports: [OrderDetailComponent],
  providers: [OrdersService, MethodService]
})
export class OrderDetailModule {}
