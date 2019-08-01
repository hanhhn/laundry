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
        loadChildren: "./login/login.module#LoginModule"
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DefaultModule {}
