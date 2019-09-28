import { Component, OnInit } from "@angular/core";
import { ConfirmationService } from "primeng/api";
import { Method } from "src/app/cores/models/method.model";
import { MethodService } from "src/app/cores/services/method.service";

@Component({
  selector: "app-method",
  templateUrl: "./method.component.html",
  styleUrls: ["./method.component.scss"]
})
export class MethodComponent implements OnInit {
  dataSource: Method[];

  constructor(
    private methodService: MethodService,
    private confirmationService: ConfirmationService
  ) {
    this.dataSource = [];
  }

  ngOnInit() {
    this.loadDataSource();
  }

  loadDataSource() {
    this.methodService.getAll(0, 100).subscribe(data => {
      this.dataSource = data.dataSource ? data.dataSource : [];
    });
  }

  onDeleteClick(item) {
    this.confirmationService.confirm({
      message: "Bạn chắc chắn muốn xóa dữ liệu",
      acceptLabel: "Xác nhận",
      rejectLabel: "Hủy",
      accept: () => {
        this.methodService.delete(item.id).subscribe(data => {
          if (data) {
            alert("Xóa dữ liệu thành công");
          } else {
            alert("Xẩy ra lỗi xin vui lòng thử lại sau.");
          }

          this.loadDataSource();
        });
      }
    });
  }
}
