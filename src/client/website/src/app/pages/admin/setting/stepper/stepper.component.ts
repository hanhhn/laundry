import { Component, OnInit } from "@angular/core";
import { SettingService } from "src/app/cores/services/setting.service";
import { ImageService } from "src/app/cores/services/image.service";
import { Guide } from "../../../../cores/models/setting.model";
import { Post } from "../../../../cores/models/post.model";
import { FormGroup, FormBuilder, Validators, FormArray } from "@angular/forms";
import { PostService } from "../../../../cores/services/post.service";
import { forkJoin } from "rxjs";

@Component({
  selector: "app-stepper",
  templateUrl: "./stepper.component.html",
  styleUrls: ["./stepper.component.scss"]
})
export class StepperComponent implements OnInit {
  submitted: boolean;
  formControls: FormGroup;

  dataSource: Post[];

  get controls() {
    return this.formControls.controls;
  }

  get steppers(): FormArray {
    return this.formControls.get("steppers") as FormArray;
  }

  constructor(
    private formBuilder: FormBuilder,
    private settingsService: SettingService,
    private imageService: ImageService,
    private postService: PostService
  ) {}

  ngOnInit() {
    this.formControls = this.formBuilder.group({
      title: [null, Validators.required],
      image: [null, Validators.required],
      description: [null],
      steppers: this.formBuilder.array([])
    });

    this.getSettings();
  }

  getSettings() {
    forkJoin([
      this.postService.getAll(0, 100),
      this.settingsService.getGuides()
    ]).subscribe(([posts, guide]) => {
      this.dataSource = posts ? posts.dataSource : [];

      if (guide && guide.steppers) {
        guide.steppers.map((value, index) => {
          const post = this.dataSource.find(x => x.id === value);
          this.steppers.controls.push(
            this.formBuilder.control(post, Validators.required)
          );
        });

        this.controls.title.setValue(guide.title);
        this.controls.image.setValue(guide.image);
        this.controls.description.setValue(guide.description);
      } else {
        this.steppers.controls.push(
          this.formBuilder.control(null, Validators.required)
        );
      }
    });
  }

  onMoreClicked(e) {
    e.preventDefault();

    this.steppers.controls.push(
      this.formBuilder.control(null, Validators.required)
    );
  }

  onRemoveClicked(i) {
    if (this.steppers.controls.length === 1) {
      return;
    }

    this.steppers.removeAt(i);
  }

  onSaveClicked(event) {
    event.preventDefault();
    this.submitted = true;
    this.formControls.markAllAsTouched();

    if (this.formControls.valid && this.steppers.valid) {
      const item = {
        title: this.controls.title.value,
        image: this.controls.image.value,
        description: this.controls.description.value,
        steppers: []
      };

      this.steppers.controls.map(control => {
        item.steppers.push(control.value.id);
      });

      this.settingsService.saveGuides(new Guide(item)).subscribe(data => {
        if (data) {
          alert("Lưu dữ liệu thành công!");
        } else {
          alert("Xảy ra lỗi");
        }
      });
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
