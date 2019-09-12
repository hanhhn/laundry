import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { LearnMoreComponent } from "./learn-more.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { SettingService } from "../../../../cores/services/setting.service";

const routes: Routes = [
  {
    path: "",
    component: LearnMoreComponent
  }
];
@NgModule({
  declarations: [LearnMoreComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes)
  ],
  providers: [SettingService]
})
export class LearnMoreModule {}
