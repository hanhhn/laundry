import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { LearnMoreComponent } from "./learn-more.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule, Routes } from "@angular/router";
import { SettingService } from "../../../../cores/services/setting.service";
import { MultiSelectModule } from "primeng/multiselect";
import { DropdownModule } from "primeng/dropdown";
import { PostService } from "src/app/cores/services/post.service";

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
    MultiSelectModule,
    RouterModule.forChild(routes)
  ],
  providers: [SettingService, PostService]
})
export class LearnMoreModule {}
