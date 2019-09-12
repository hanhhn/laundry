import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FlexLayoutModule } from "@angular/flex-layout";
import { PostListComponent } from "./post-list.component";
import { PostItemComponent } from "../post-item/post-item.component";

@NgModule({
  declarations: [PostListComponent, PostItemComponent],
  imports: [CommonModule, FlexLayoutModule],
  exports: [PostListComponent]
})
export class PostListModule {}
