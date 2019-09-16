import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ImageService } from "src/app/cores/services/image.service";
import { Router, ActivatedRoute } from "@angular/router";
import { Item, ItemRequest } from "../../../../cores/models/item.model";
import { ItemService } from "../../../../cores/services/item.service";
import { KeyValue } from "../../../../cores/models/object.model";
import { Method } from "../../../../cores/models/method.model";
import { MethodService } from "../../../../cores/services/method.service";
import { forkJoin } from "rxjs";

@Component({
  selector: "app-service-detail",
  templateUrl: "./service-detail.component.html",
  styleUrls: ["./service-detail.component.scss"]
})
export class ServiceDetailComponent implements OnInit {
  id: number;
  item: Item;

  itemTypes: KeyValue[];
  methods: Method[];

  submitted: boolean;
  formControls: FormGroup;

  constructor(
    route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private itemService: ItemService,
    private imageService: ImageService,
    private methodService: MethodService
  ) {
    this.submitted = false;
    this.id = 0;

    route.params.subscribe(param => {
      if (param && param.id) {
        this.id = param.id;
      }
    });

    this.itemTypes = [];
    this.submitted = false;
  }

  get controls() {
    return this.formControls.controls;
  }

  ngOnInit() {
    this.formControls = this.formBuilder.group({
      id: [0],
      type: [null, Validators.required],
      image: [null, Validators.required],
      name: [null, Validators.required],
      method: [null],
      description: [null, Validators.required],
      sortOrder: [1, Validators.required],
      highlight: [false, Validators.required]
    });

    forkJoin([
      this.itemService.getItemTypes(),
      this.methodService.getAll(0, 100),
      this.itemService.get(this.id)
    ]).subscribe(([itemsType, methods, item]) => {
      this.itemTypes = itemsType;
      this.methods = methods ? methods.dataSource : [];

      if (item) {
        const type = this.itemTypes.find(x => x.key === item.type);
        const method = this.methods.find(x => x.id === item.methodId);
        this.controls.id.patchValue(item.id);
        this.controls.type.patchValue(type);
        this.controls.image.patchValue(item.image);
        this.controls.name.patchValue(item.name);
        this.controls.method.patchValue(method);
        this.controls.description.patchValue(item.description);
        this.controls.sortOrder.patchValue(item.sortOrder);
        this.controls.highlight.patchValue(item.highlight);
      }
    });
  }

  onSaveItemClick() {
    this.submitted = true;
    this.formControls.markAllAsTouched();

    if (this.formControls.valid) {
      const request = new ItemRequest();
      request.id = this.controls.id.value;
      request.name = this.controls.name.value;
      request.type = this.controls.type.value.key;
      request.methodId = this.controls.method.value.id;
      request.image = this.controls.image.value;
      request.description = this.controls.description.value;
      request.sortOrder = this.controls.sortOrder.value;
      request.highlight = this.controls.highlight.value;

      this.itemService.saveItem(request).subscribe(
        data => {
          if (data) {
            alert("Lưu dữ liệu thành công");
          } else {
            alert("Xẩy ra lỗi xin vui lòng thử lại sau.");
          }
        },
        err => {
          alert(err);
        }
      );
    }
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
