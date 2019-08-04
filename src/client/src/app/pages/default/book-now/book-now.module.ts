import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { BookNowComponent } from "./book-now.component";

const routes: Routes = [
  {
    path: "",
    component: BookNowComponent
  }
];

@NgModule({
  declarations: [BookNowComponent],
  imports: [CommonModule, RouterModule.forChild(routes)]
})
export class BookNowModule {}
