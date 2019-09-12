import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./home.component";
import { ServiceModule } from "../../../components/service/service.module";
import { GuideModule } from "../../../components/guide/guide.module";
import { DownloadAppModule } from "../../../components/download-app/download-app.module";
import { SelectionModule } from "../../../components/selection/selection.module";
import { SettingService } from "src/app/cores/services/setting.service";
import { JumbotronModule } from "src/app/components/jumbotron/jumbotron.module";
import { PostListModule } from "../../../components/post-list/post-list.module";

const routes: Routes = [
  {
    path: "",
    component: HomeComponent
  }
];

@NgModule({
  declarations: [HomeComponent],
  imports: [
    CommonModule,
    JumbotronModule,
    GuideModule,
    ServiceModule,
    DownloadAppModule,
    SelectionModule,
    PostListModule,
    RouterModule.forChild(routes)
  ],
  providers: [SettingService]
})
export class HomeModule {}
