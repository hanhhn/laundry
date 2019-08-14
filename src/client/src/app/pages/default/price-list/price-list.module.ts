import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { PriceListComponent } from "./price-list.component";
import { FlexLayoutModule } from "@angular/flex-layout";
import { MatTabsModule, MatIconModule } from "@angular/material";
import { ServiceModule } from "src/app/components/service/service.module";
import { ItemListModule } from "src/app/components/item-list/item-list.module";
import { ServiceListModule } from "src/app/components/service-list/service-list.module";

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
    FlexLayoutModule,
    MatTabsModule,
    MatIconModule,
    ServiceListModule,
    ItemListModule,
    RouterModule.forChild(routes)
  ]
})
export class PriceListModule {}
