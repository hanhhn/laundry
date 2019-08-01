import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { NotFoundComponent } from "./pages/error/not-found/not-found.component";

const routes: Routes = [
  {
    path: "",
    loadChildren: "./layouts/default-layout/default-layout.module#DefaultLayoutModule"
  },
  {
    path: "admin",
    loadChildren: "./layouts/admin-layout/admin-layout.module#AdminLayoutModule"
  },
  {
    path: "**",
    component: NotFoundComponent,
  }
];
@NgModule({
  declarations: [NotFoundComponent],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
