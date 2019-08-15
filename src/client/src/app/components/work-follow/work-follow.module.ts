import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { WorkFollowComponent } from "./work-follow.component";
import { WorkListModule } from "../work-list/work-list.module";
import { FlexLayoutModule } from "@angular/flex-layout";

@NgModule({
  declarations: [WorkFollowComponent],
  imports: [CommonModule, WorkListModule, FlexLayoutModule],
  exports: [WorkFollowComponent]
})
export class WorkFollowModule {}
