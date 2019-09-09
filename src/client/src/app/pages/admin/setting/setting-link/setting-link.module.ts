import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { SettingLinkComponent } from "./setting-link.component";
import { Routes, RouterModule } from "@angular/router";

const routes: Routes = [
  {
    path: "",
    component: SettingLinkComponent
  }
];
@NgModule({
  declarations: [SettingLinkComponent],
  imports: [CommonModule, RouterModule.forChild(routes)]
})
export class SettingLinkModule {}
