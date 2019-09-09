import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { SettingCompanyComponent } from "./setting-company.component";
import { Routes, RouterModule } from "@angular/router";

const routes: Routes = [
  {
    path: "",
    component: SettingCompanyComponent
  }
];
@NgModule({
  declarations: [SettingCompanyComponent],
  imports: [CommonModule, RouterModule.forChild(routes)]
})
export class SettingCompanyModule {}
