import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { PriceListComponent } from "./price-list.component";
import { FlexLayoutModule } from "@angular/flex-layout";
import { MatTabsModule, MatIconModule } from "@angular/material";
import { ServiceListModule } from "src/app/components/service-list/service-list.module";
import { ItemService } from "../../../cores/services/item.service";
import { ItemModule } from "../../../components/item/item.module";

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
    ItemModule,
    RouterModule.forChild(routes)
  ],
  providers: [ItemService]
})
export class PriceListModule {}
