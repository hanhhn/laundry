import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { NotFoundComponent } from "./pages/error/not-found/not-found.component";
import { AdminLayoutComponent } from "./layouts/admin-layout/admin-layout.component";
import { DefaultLayoutComponent } from "./layouts/default-layout/default-layout.component";
import { DefaultLayoutModule } from "./layouts/default-layout/default-layout.module";
import { AdminLayoutModule } from "./layouts/admin-layout/admin-layout.module";

const routes: Routes = [
  {
    path: "",
    component: DefaultLayoutComponent,
    children: [
      {
        path: "",
        redirectTo: "trang-chu",
        pathMatch: "full"
      },
      {
        path: "trang-chu",
        loadChildren: "./pages/default/home/home.module#HomeModule"
      },
      {
        path: "dang-nhap",
        loadChildren: "./pages/default/sign-in/sign-in.module#SignInModule"
      },
      {
        path: "dang-ky",
        loadChildren: "./pages/default/sign-up/sign-up.module#SignUpModule"
      },
      {
        path: "ve-chung-toi",
        loadChildren: "./pages/default/about/about.module#AboutModule"
      },
      {
        path: "quy-trinh",
        loadChildren: "./pages/default/process/process.module#ProcessModule"
      },
      {
        path: "bang-gia",
        loadChildren:
          "./pages/default/price-list/price-list.module#PriceListModule"
      },
      {
        path: "lien-he",
        loadChildren: "./pages/default/contact/contact.module#ContactModule"
      },
      {
        path: "dat-ngay",
        loadChildren: "./pages/default/book-now/book-now.module#BookNowModule"
      },
      {
        path: "order/tracking",
        loadChildren: "./pages/default/tracking/tracking.module#TrackingModule"
      },
      {
        path: "ma-giam-gia",
        loadChildren: "./pages/default/discount/discount.module#DiscountModule"
      }
    ]
  },
  {
    path: "admin",
    component: AdminLayoutComponent,
    children: [
      {
        path: "",
        redirectTo: "dashboard",
        pathMatch: "full"
      },
      {
        path: "dashboard",
        loadChildren: "./pages/admin/dashboard/dashboard.module#DashboardModule"
      },
      {
        path: "order",
        loadChildren: "./pages/admin/order/order.module#OrderModule"
      },
      {
        path: "price",
        loadChildren: "./pages/admin/price-list/price-list.module#PriceListModule"
      },
      {
        path: "service",
        loadChildren: "./pages/admin/service/service.module#ServiceModule"
      },
      {
        path: "method",
        loadChildren: "./pages/admin/method/method.module#MethodModule"
      },
      {
        path: "discount",
        loadChildren: "./pages/admin/coupon/coupon.module#CouponModule"
      },
      {
        path: "setting/company",
        loadChildren: "./pages/admin/setting/company/company.module#CompanyModule"
      },
      {
        path: "setting/reasons",
        loadChildren: "./pages/admin/setting/reason/reason.module#ReasonModule"
      },
    ]
  },
  {
    path: "**",
    component: NotFoundComponent
  }
];
@NgModule({
  declarations: [NotFoundComponent],
  imports: [
    DefaultLayoutModule,
    AdminLayoutModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}
