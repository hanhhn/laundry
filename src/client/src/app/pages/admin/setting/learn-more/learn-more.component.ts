import { Component, OnInit } from "@angular/core";
import { FormGroup } from '@angular/forms';

@Component({
  selector: "app-learn-more",
  templateUrl: "./learn-more.component.html",
  styleUrls: ["./learn-more.component.scss"]
})
export class LearnMoreComponent implements OnInit {
  submitted: boolean;
  formControls: FormGroup;

  data: Reason;

  get controls() {
    return this.formControls.controls;
  }

  get reasonControls() {
    const controls = [];
    // tslint:disable-next-line: forin
    for (const field in this.controls) {
      if (field !== "title" && field !== "image" && field !== "description") {
        controls.push(field);
      }
    }
    return controls;
  }

  constructor(
    private formBuilder: FormBuilder,
    private settingsService: SettingService,
    private imageService: ImageService
  ) {}

  ngOnInit() {
    this.getSettings();
  }

  getSettings() {
    this.settingsService.getReason().subscribe(data => {
      this.data = data ? data : null;

      this.formControls = this.formBuilder.group({
        title: [this.data.title ? this.data.title : null, Validators.required],
        image: [this.data.image ? this.data.image : null],
        description: [this.data.description ? this.data.description : null]
      });

      if (this.data && this.data.reasons && this.data.reasons.length > 0) {
        this.data.reasons.map((value, index) => {
          this.formControls.addControl(
            "reason" + index + 1,
            new FormControl(value, Validators.required)
          );
        });
      } else {
        for (let i = 0; i < 6; i++) {
          this.formControls.addControl(
            "reason" + i,
            new FormControl(null, Validators.required)
          );
        }
      }
    });
  }

  onMoreReasonClicked(e) {
    e.preventDefault();

    this.formControls.addControl(
      "reason" + Math.floor(Math.random() * 1000),
      new FormControl(null, Validators.required)
    );
  }

  onRmoveReasonClicked(control) {
    this.formControls.removeControl(control);
  }

  onSaveClicked(event) {
    event.preventDefault();
    this.submitted = true;
    this.formControls.markAllAsTouched();

    if (this.formControls.valid) {
      const item = {
        title: this.controls.title.value,
        image: this.controls.image.value,
        description: this.controls.description.value,
        reasons: []
      };

      this.reasonControls.forEach((value, index) => {
        const reason = this.formControls.get(value).value;
        item.reasons.push(reason);
      });

      this.settingsService.saveReason(new Reason(item)).subscribe(data => {
        if (data) {
          alert("Lưu dữ liệu thành công!");
        } else {
          alert("Xảy ra lỗi");
        }
      });
    }
  }
}
