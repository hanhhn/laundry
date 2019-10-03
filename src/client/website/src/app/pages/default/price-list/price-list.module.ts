import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { PriceListComponent } from "./price-list.component";
import { FlexLayoutModule } from "@angular/flex-layout";
import { ItemService } from "../../../cores/services/item.service";
import { ItemModule } from "../../../components/item/item.module";
import { ComboModule } from "../../../components/combo/combo.module";
import { PriceItemModule } from "../../../components/price-item/price-item.module";
import { MatTabsModule } from "@angular/material/tabs";
import { MatIconModule } from "@angular/material/icon";
import { MatButtonModule } from "@angular/material/button";
import { MatCardModule } from "@angular/material/card";

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
    ItemModule,
    MatButtonModule,
    MatCardModule,
    ComboModule,
    PriceItemModule,
    RouterModule.forChild(routes)
  ],
  providers: [ItemService]
})
export class PriceListModule {}
