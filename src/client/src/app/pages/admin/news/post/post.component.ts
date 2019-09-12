import { Component, OnInit } from "@angular/core";
import { PostService } from "src/app/cores/services/post.service";
import { Post } from "src/app/cores/models/post.model";
import { ConfirmationService } from "primeng/api";

@Component({
  selector: "app-post",
  templateUrl: "./post.component.html",
  styleUrls: ["./post.component.scss"]
})
export class PostComponent implements OnInit {
  dataSource: Post[];

  constructor(
    private postService: PostService,
    private confirmationService: ConfirmationService
  ) {}

  ngOnInit() {
    this.loadDataDataSource(0, 100);
  }

  loadDataDataSource(pageIndex: number, pageSize: number) {
    this.postService.getAll(pageIndex, pageSize).subscribe(data => {
      this.dataSource = data.dataSource;
    });
  }

  onEditClicked(item: Post) {}

  onDeleteClick(item) {
    this.confirmationService.confirm({
      message: "Bạn chắc chắn muốn xóa '" + item.name + "'",
      acceptLabel: "Xác nhận",
      rejectLabel: "Hủy",
      accept: () => {
        this.postService.delete(item.id).subscribe(data => {
          if (data) {
            alert("Xóa dữ liệu thành công");
          } else {
            alert("Xẩy ra lỗi xin vui lòng thử lại sau.");
          }

          this.loadDataDataSource(0, 100);
        });
      },
      reject: () => {}
    });
  }
}
