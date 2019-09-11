import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { SettingService } from "src/app/cores/services/setting.service";
import { Company, Jumbotron } from "src/app/cores/models/setting.model";
import { ImageService } from "src/app/cores/services/image.service";

@Component({
  selector: "app-company",
  templateUrl: "./jumbotron.component.html",
  styleUrls: ["./jumbotron.component.scss"]
})
export class JumbotronComponent implements OnInit {
  submitted: boolean;
  formControls: FormGroup;

  get controls() {
    return this.formControls.controls;
  }

  constructor(
    private formBuilder: FormBuilder,
    private settingsService: SettingService,
    private imageService: ImageService
  ) {}

  ngOnInit() {
    this.intiFormControls();
    this.getExternalLink();
  }

  intiFormControls() {
    this.formControls = this.formBuilder.group({
      background: [null],
      title: [null, Validators.required],
      description: [null, Validators.required],
      firstButton: [null, Validators.required],
      firstLink: [null, Validators.required],
      secondButton: [null, Validators.required],
      secondLink: [null, Validators.required]
    });
  }

  getExternalLink() {
    this.settingsService.getJumbotron().subscribe(data => {
      if (data) {
        this.controls.background.patchValue(data.background);
        this.controls.title.patchValue(data.title);
        this.controls.description.patchValue(data.description);
        this.controls.firstButton.patchValue(data.firstButton);
        this.controls.firstLink.patchValue(data.firstLink);
        this.controls.secondButton.patchValue(data.secondButton);
        this.controls.secondLink.patchValue(data.secondLink);
      }
    });
  }

  onSaveClicked(event) {
    event.preventDefault();
    this.submitted = true;
    this.formControls.markAllAsTouched();

    if (this.formControls.valid) {
      const item = {
        background: this.controls.background.value,
        title: this.controls.title.value,
        description: this.controls.description.value,
        firstButton: this.controls.firstButton.value,
        firstLink: this.controls.firstLink.value,
        secondButton: this.controls.secondButton.value,
        secondLink: this.controls.secondLink.value
      };

      this.settingsService
        .saveJumbotron(new Jumbotron(item))
        .subscribe(data => {
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
              this.controls.logo.setValue(respon.data.link);
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
