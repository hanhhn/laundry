import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { PriceListComponent } from "./price-list.component";
import { ItemModule } from "../../../components/item/item.module";
import { FlexLayoutModule } from "@angular/flex-layout";

const routes: Routes = [
  {
    path: "",
    component: PriceListComponent
  }
];

@NgModule({
  declarations: [PriceListComponent],
  imports: [
    CommonModule,
    ItemModule,
    FlexLayoutModule,
    RouterModule.forChild(routes)
  ]
})
export class PriceListModule {}
