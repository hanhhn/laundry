import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { AdminLayoutComponent } from "./admin-layout.component";
import { AdminModule } from "src/app/pages/admin/admin.module";

@NgModule({
  declarations: [AdminLayoutComponent],
  imports: [CommonModule, AdminModule]
})
export class AdminLayoutModule {}
