import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { DefaultLayoutComponent } from "./layouts/default-layout/default-layout.component";
import { AdminLayoutComponent } from "./layouts/admin-layout/admin-layout.component";

const routes: Routes = [
  {
    path: "",
    component: DefaultLayoutComponent,
    loadChildren: "./pages/default/default.module#DefaultModule"
  },
  {
    path: "admin",
    component: AdminLayoutComponent,
    loadChildren: "./pages/admin/admin.module#AdminModule"
  }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
