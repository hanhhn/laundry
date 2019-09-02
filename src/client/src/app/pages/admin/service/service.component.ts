import { Component, OnInit } from "@angular/core";
import { ItemService } from "../../../cores/services/item.service";
import { Item, ItemRequest } from "../../../cores/models/item.model";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ImageService } from "../../../cores/services/image.service";
import { ConfirmationService } from "primeng/api";

@Component({
  selector: "app-service",
  templateUrl: "./service.component.html",
  styleUrls: ["./service.component.scss"]
})
export class ServiceComponent implements OnInit {
  dataSource: Item[] = [];

  display = false;

  submitted = false;
  formControls: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private itemService: ItemService,
    private imageService: ImageService,
    private confirmationService: ConfirmationService
  ) {}

  get controls() {
    return this.formControls.controls;
  }

  private markAllControlDirty(): void {
    // tslint:disable-next-line:forin
    for (const i in this.formControls.controls) {
      this.formControls.controls[i].markAsDirty();
    }
  }

  ngOnInit() {
    this.loadItemList();

    this.formControls = this.formBuilder.group({
      id: [0],
      image: [null, Validators.required],
      name: [null, Validators.required],
      description: [null],
      order: [1, Validators.required],
      highlights: [false]
    });
  }

  loadItemList() {
    this.itemService.getAll(0, 10).subscribe(data => {
      this.dataSource = data.dataSource ? data.dataSource : [];
    });
  }

  onShowAddDialog() {
    this.display = true;

    this.formControls = this.formBuilder.group({
      id: [0],
      image: [null, Validators.required],
      name: [null, Validators.required],
      description: [null],
      order: [1, Validators.required],
      highlights: [false]
    });
  }

  onShowEditDialog(item: Item) {
    this.display = true;

    this.formControls = this.formBuilder.group({
      id: [item.id],
      image: [item.image, Validators.required],
      name: [item.name, Validators.required],
      description: [item.description],
      order: [item.order, Validators.required],
      highlights: [item.highlights]
    });
  }

  onSaveItemClick() {
    this.submitted = true;
    this.formControls.markAsDirty();
    this.markAllControlDirty();

    if (this.formControls.valid) {
      const request = new ItemRequest();
      request.id = this.controls.id.value;
      request.image = this.controls.image.value;
      request.name = this.controls.name.value;
      request.description = this.controls.description.value;
      request.order = this.controls.order.value;
      request.highlights = this.controls.highlights.value;

      this.itemService.saveItem(request).subscribe(
        data => {
          if (data) {
            alert("Lưu dữ liệu thành công");
          } else {
            alert("Xẩy ra lỗi xin vui lòng thử lại sau.");
          }

          this.display = false;
          this.loadItemList();
        },
        err => {
          alert(err);
        }
      );
    }
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

  onImageSelected(event: any) {
    if (event.files && event.files.length > 0) {
      const file = event.files[0];

      // file size max 2mb
      if (file && file.size < 2097152) {
        this.imageService.uploadToImgur(
          file,
          respon => {
            if (respon && respon.status === 200) {
              this.controls.image.setValue(respon.data.link);
            }
          },
          error => {
            alert("Xẩy ra lỗi xin vui lòng thử lại sau.");
          }
        );
      }
    }
  }
}
