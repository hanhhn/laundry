import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { WorkListComponent } from "./work-list.component";
import { WorkItemComponent } from "../work-item/work-item.component";
import { FlexLayoutModule } from "@angular/flex-layout";

@NgModule({
  declarations: [WorkListComponent, WorkItemComponent],
  imports: [CommonModule, FlexLayoutModule],
  exports: [WorkListComponent]
})
export class WorkListModule {}
