import { Component, OnInit } from "@angular/core";
import { ConfirmationService } from "primeng/api";
import { Item } from "../../../../cores/models/item.model";
import { ItemService } from "../../../../cores/services/item.service";

@Component({
  selector: "app-service",
  templateUrl: "./service.component.html",
  styleUrls: ["./service.component.scss"]
})
export class ServiceComponent implements OnInit {
  dataSource: Item[];

  constructor(
    private itemService: ItemService,
    private confirmationService: ConfirmationService
  ) {
    this.dataSource = [];
  }

  ngOnInit() {
    this.loadItemList();
  }

  loadItemList() {
    this.itemService.getAll(0, 100).subscribe(data => {
      this.dataSource = data.dataSource ? data.dataSource : [];
    });
  }

  onDeleteItemClick(item) {
    this.confirmationService.confirm({
      message: "Bạn chắc chắn muốn xóa '" + item.name + "'",
      acceptLabel: "Xác nhận",
      rejectLabel: "Hủy",
      accept: () => {
        this.itemService.deleteItem(item.id).subscribe(data => {
          if (data) {
            alert("Xóa dữ liệu thành công");
          } else {
            alert("Xẩy ra lỗi xin vui lòng thử lại sau.");
          }

          this.loadItemList();
        });
      },
      reject: () => {}
    });
  }
}
