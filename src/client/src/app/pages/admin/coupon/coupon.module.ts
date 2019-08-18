import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { CouponComponent } from "./coupon.component";
import { Routes, RouterModule } from "@angular/router";

const routes: Routes = [
  {
    path: "",
    component: CouponComponent
  }
];

@NgModule({
  declarations: [CouponComponent],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [CouponComponent]
})
export class CouponModule {}
