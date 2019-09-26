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
        path: "order/:id",
        loadChildren: "./pages/admin/order/order-detail/order-detail.module#OrderDetailModule"
      },
      {
        path: "order",
        loadChildren: "./pages/admin/order/order/order.module#OrderModule"
      },
      {
        path: "price",
        loadChildren:
          "./pages/admin/price-list/price-list.module#PriceListModule"
      },
      {
        path: "service/add",
        loadChildren:
          "./pages/admin/service/service-detail/service-detail.module#ServiceDetailModule"
      },
      {
        path: "service/detail/:id",
        loadChildren:
          "./pages/admin/service/service-detail/service-detail.module#ServiceDetailModule"
      },
      {
        path: "service",
        loadChildren: "./pages/admin/service/service/service.module#ServiceModule"
      },
      {
        path: "method",
        loadChildren: "./pages/admin/method/method.module#MethodModule"
      },
      {
        path: "post/add",
        loadChildren:
          "./pages/admin/post/post-detail/post-detail.module#PostDetailModule"
      },
      {
        path: "post/detail/:id",
        loadChildren:
          "./pages/admin/post/post-detail/post-detail.module#PostDetailModule"
      },
      {
        path: "post",
        loadChildren: "./pages/admin/post/post/post.module#PostModule"
      },
      {
        path: "page/add",
        loadChildren:
          "./pages/admin/page/page-detail/page-detail.module#PageDetailModule"
      },
      {
        path: "page/detail/:id",
        loadChildren:
          "./pages/admin/page/page-detail/page-detail.module#PageDetailModule"
      },
      {
        path: "page",
        loadChildren: "./pages/admin/page/page/page.module#PageModule"
      },
      {
        path: "discount",
        loadChildren: "./pages/admin/coupon/coupon.module#CouponModule"
      },
      {
        path: "setting/company",
        loadChildren:
          "./pages/admin/setting/company/company.module#CompanyModule"
      },
      {
        path: "setting/reasons",
        loadChildren: "./pages/admin/setting/reason/reason.module#ReasonModule"
      },
      {
        path: "setting/jumbotron",
        loadChildren:
          "./pages/admin/setting/jumbotron/jumbotron.module#JumbotronModule"
      },
      {
        path: "setting/process",
        loadChildren:
          "./pages/admin/setting/learn-more/learn-more.module#LearnMoreModule"
      },
      {
        path: "setting/guide",
        loadChildren:
          "./pages/admin/setting/stepper/stepper.module#StepperModule"
      },
      {
        path: "setting/combo",
        loadChildren: "./pages/admin/setting/combo/combo.module#ComboModule"
      }
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
