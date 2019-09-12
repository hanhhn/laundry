import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Post, PostRequest } from "src/app/cores/models/post.model";
import { PostService } from "src/app/cores/services/post.service";
import { ImageService } from "src/app/cores/services/image.service";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-post-detail",
  templateUrl: "./post-detail.component.html",
  styleUrls: ["./post-detail.component.scss"]
})
export class PostDetailComponent implements OnInit {
  post: Post;

  submitted: boolean;
  formControls: FormGroup;

  id: string;

  constructor(
    route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private postService: PostService,
    private imageService: ImageService
  ) {
    this.submitted = false;
    route.params.subscribe(param => {
      if (param) {
        this.id = param.id;
      }
    });
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
      isPublished: [false]
    });

    if (this.id) {
      this.postService.getById(this.id).subscribe(data => {
        if (data) {
          this.controls.id.patchValue(data.id);
          this.controls.image.patchValue(data.image);
          this.controls.title.patchValue(data.title);
          this.controls.uniqueUrl.patchValue(data.uniqueUrl);
          this.controls.description.patchValue(data.description);
          this.controls.body.patchValue(data.body);
          this.controls.isPublished.patchValue(data.isPublished);
        }
      });
    }
  }

  onSaveItemClick() {
    this.submitted = true;
    this.formControls.markAllAsTouched();

    if (this.formControls.valid) {
      const request = new PostRequest();
      request.id = this.controls.id.value;
      request.image = this.controls.image.value;
      request.title = this.controls.title.value;
      request.uniqueUrl = this.controls.uniqueUrl.value;
      request.description = this.controls.description.value;
      request.body = this.controls.body.value;
      request.isPublished = this.controls.isPublished.value;

      this.postService.save(request).subscribe(
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
