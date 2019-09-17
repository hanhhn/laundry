import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Page, PageRequest } from "src/app/cores/models/page.model";
import { PageService } from "src/app/cores/services/page.service";
import { ImageService } from "src/app/cores/services/image.service";
import { Router, ActivatedRoute } from "@angular/router";
import { vnToEn, formatDate } from "src/app/cores/helpers/utils.helper";

@Component({
  selector: "app-page-detail",
  templateUrl: "./page-detail.component.html",
  styleUrls: ["./page-detail.component.scss"]
})
export class PageDetailComponent implements OnInit {
  id: string;
  page: Page;

  submitted: boolean;
  formControls: FormGroup;

  validUniqueUrl: boolean;

  constructor(
    route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private pageService: PageService,
    private imageService: ImageService
  ) {
    this.submitted = false;
    route.params.subscribe(param => {
      if (param && param.id) {
        this.id = param.id;
      }
    });
    this.validUniqueUrl = true;
  }

  get controls() {
    return this.formControls.controls;
  }

  ngOnInit() {
    this.formControls = this.formBuilder.group({
      id: [0],
      image: [null, Validators.required],
      title: [null, Validators.required],
      uniqueUrl: [null, Validators.required],
      description: [null, Validators.required],
      body: [null, Validators.required],
      sortOrder: [1, Validators.required]
    });

    this.controls.uniqueUrl.disable();

    if (this.id) {
      this.pageService.getById(this.id).subscribe(data => {
        if (data) {
          this.controls.id.patchValue(data.id);
          this.controls.image.patchValue(data.image);
          this.controls.title.patchValue(data.title);
          this.controls.uniqueUrl.patchValue(data.uniqueUrl);
          this.controls.description.patchValue(data.description);
          this.controls.body.patchValue(data.body);
          this.controls.sortOrder.patchValue(data.sortOrder);
        }
      });
    }
  }

  onSaveItemClick() {
    this.submitted = true;
    this.formControls.markAllAsTouched();

    if (this.formControls.valid) {
      const request = new PageRequest();
      request.id = this.controls.id.value;
      request.image = this.controls.image.value;
      request.title = this.controls.title.value;
      request.uniqueUrl = this.controls.uniqueUrl.value;
      request.description = this.controls.description.value;
      request.body = this.controls.body.value;
      request.sortOrder = this.controls.sortOrder.value;

      this.pageService.save(request).subscribe(
        data => {
          if (data) {
            alert("Lưu dữ liệu thành công");
            this.router.navigate(["/admin/page"]);
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

  onEditUniqueUrlClicked(e) {
    this.controls.uniqueUrl.enable();
  }

  onTitleChanged(e) {
    if (e && e.target.value) {
      this.controls.uniqueUrl.patchValue(
        vnToEn(e.target.value) + "-" + formatDate(new Date(), null)
      );

      this.pageService
        .isUniqueUrl(this.controls.uniqueUrl.value)
        .subscribe(valid => {
          this.validUniqueUrl = valid;
        });
    }
  }

  onUniqueUrlChanged(e) {
    this.pageService
      .isUniqueUrl(this.controls.uniqueUrl.value)
      .subscribe(valid => {
        this.validUniqueUrl = valid;
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
