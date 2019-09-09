import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { SettingService } from "src/app/cores/services/setting.service";
import { Company } from "src/app/cores/models/setting.model";
import { ImageService } from "src/app/cores/services/image.service";

@Component({
  selector: "app-company",
  templateUrl: "./company.component.html",
  styleUrls: ["./company.component.scss"]
})
export class CompanyComponent implements OnInit {
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
      brand: [null, Validators.required],
      logo: [null],
      name: [null, Validators.required],
      address: [null, Validators.required],
      email: [null, Validators.required],
      phone: [null, Validators.required],
      website: [null, Validators.required],
      copyright: [null, Validators.required],
      facebook: [null, Validators.required],
      instagram: [null, Validators.required],
      youtube: [null, Validators.required],
      appStore: [null, Validators.required],
      googlePlay: [null, Validators.required],
      googleMap: [null, Validators.required]
    });
  }

  getExternalLink() {
    this.settingsService.getCompanyInfo().subscribe(data => {
      if (data) {
        this.controls.brand.patchValue(data.brand);
        this.controls.logo.patchValue(data.logo);
        this.controls.name.patchValue(data.name);
        this.controls.address.patchValue(data.address);
        this.controls.email.patchValue(data.email);
        this.controls.phone.patchValue(data.phone);
        this.controls.website.patchValue(data.website);
        this.controls.copyright.patchValue(data.copyright);
        this.controls.facebook.patchValue(data.facebook);
        this.controls.instagram.patchValue(data.instagram);
        this.controls.youtube.patchValue(data.youtube);
        this.controls.appStore.patchValue(data.appStore);
        this.controls.googlePlay.patchValue(data.googlePlay);
        this.controls.googleMap.patchValue(data.googleMap);
      }
    });
  }

  onSaveClicked(event) {
    event.preventDefault();
    this.submitted = true;
    this.formControls.markAllAsTouched();

    if (this.formControls.valid) {
      const item = {
        brand: this.controls.brand.value,
        logo: this.controls.logo.value,
        name: this.controls.name.value,
        address: this.controls.address.value,
        email: this.controls.email.value,
        phone: this.controls.phone.value,
        website: this.controls.website.value,
        copyright: this.controls.copyright.value,
        facebook: this.controls.facebook.value,
        instagram: this.controls.instagram.value,
        youtube: this.controls.youtube.value,
        appStore: this.controls.appStore.value,
        googlePlay: this.controls.googlePlay.value,
        googleMap: this.controls.googleMap.value
      };

      this.settingsService
        .saveCompanyInfo(new Company(item))
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
