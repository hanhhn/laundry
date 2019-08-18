import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { PriceListComponent } from "./price-list.component";
import { Routes, RouterModule } from "@angular/router";

const routes: Routes = [
  {
    path: "",
    component: PriceListComponent
  }
];

@NgModule({
  declarations: [PriceListComponent],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [PriceListComponent]
})
export class PriceListModule {}
