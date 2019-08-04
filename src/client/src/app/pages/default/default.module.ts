import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { DefaultLayoutComponent } from "src/app/layouts/default-layout/default-layout.component";

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
        loadChildren: "./home/home.module#HomeModule"
      },
      {
        path: "dang-nhap",
        loadChildren: "./sign-in/sign-in.module#SignInModule"
      },
      {
        path: "dang-ky",
        loadChildren: "./sign-up/sign-up.module#SignUpModule"
      },
      {
        path: "ve-chung-toi",
        loadChildren: "./about/about.module#AboutModule"
      },
      {
        path: "dich-vu-va-quy-trinh",
        loadChildren: "./process/process.module#ProcessModule"
      },
      {
        path: "bang-gia",
        loadChildren: "./price-list/price-list.module#PriceListModule"
      },
      {
        path: "lien-he",
        loadChildren: "./contact/contact.module#ContactModule"
      },
      {
        path: "dat-ngay",
        loadChildren: "./book-now/book-now.module#BookNowModule"
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DefaultModule {}
