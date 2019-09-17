import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { PriceListComponent } from "./price-list.component";
import { FlexLayoutModule } from "@angular/flex-layout";
import {
  MatTabsModule,
  MatIconModule,
  MatButtonModule,
  MatCardModule
} from "@angular/material";
import { ItemService } from "../../../cores/services/item.service";
import { ItemModule } from "../../../components/item/item.module";
import { PriceItemComponent } from "src/app/components/price-item/price-item.component";
import { ComboComponent } from "src/app/components/combo/combo.component";
import { KConverterPipe } from "src/app/cores/pipes/k.pipe";
import { ComboModule } from "../../../components/combo/combo.module";
import { PriceItemModule } from "../../../components/price-item/price-item.module";

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
