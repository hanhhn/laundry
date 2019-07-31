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
        loadChildren: "./home/home.module#HomeModule"
      },
      {
        path: "login",
        loadChildren: "./login/login.module#LoginModule"
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class DefaultModule {}
