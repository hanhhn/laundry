import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { SettingAllComponent } from "./setting-all.component";
import { Routes, RouterModule } from "@angular/router";

const routes: Routes = [
  {
    path: "",
    component: SettingAllComponent
  }
];

@NgModule({
  declarations: [SettingAllComponent],
  imports: [CommonModule, RouterModule.forChild(routes)]
})
export class SettingAllModule {}
