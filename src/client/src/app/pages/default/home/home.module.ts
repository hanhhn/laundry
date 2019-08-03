import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./home.component";
import { CarouselModule } from "../../../components/carousel/carousel.module";
import { ServiceModule } from "../../../components/service/service.module";
import { ProcessModule } from "../../../components/process/process.module";

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
    CarouselModule,
    ProcessModule,
    ServiceModule,
    RouterModule.forChild(routes)
  ]
})
export class HomeModule {}
