import { Component, OnInit } from "@angular/core";
import { ConfirmationService } from "primeng/api";
import { Page } from "../../../../cores/models/page.model";
import { PageService } from "../../../../cores/services/page.service";

@Component({
  selector: "app-page",
  templateUrl: "./page.component.html",
  styleUrls: ["./page.component.scss"]
})
export class PageComponent implements OnInit {
  dataSource: Page[];

  constructor(
    private pageService: PageService,
    private confirmationService: ConfirmationService
  ) {}

  ngOnInit() {
    this.loadDataDataSource(0, 100);
  }

  loadDataDataSource(pageIndex: number, pageSize: number) {
    this.pageService.getAll(pageIndex, pageSize).subscribe(data => {
      this.dataSource = data.dataSource;
    });
  }

  onDeleteClick(item: Page) {
    this.confirmationService.confirm({
      message: "Bạn chắc chắn muốn xóa '" + item.title + "'",
      acceptLabel: "Xác nhận",
      rejectLabel: "Hủy",
      accept: () => {
        this.pageService.delete(item.id).subscribe(data => {
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
