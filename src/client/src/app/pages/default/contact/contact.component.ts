import { Component, OnInit } from "@angular/core";
import { Company, Reason } from "../../../cores/models/setting.model";
import { DomSanitizer, SafeUrl } from "@angular/platform-browser";
import { SettingService } from "src/app/cores/services/setting.service";
import { SniperService } from "../../../cores/services/sniper.service";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";

@Component({
  selector: "app-contact",
  templateUrl: "./contact.component.html",
  styleUrls: ["./contact.component.scss"]
})
export class ContactComponent implements OnInit {
  submitted: boolean;
  formControls: FormGroup;

  get controls() {
    return this.formControls.controls;
  }

  companyInfo: Company;

  googleMap: SafeUrl;

  constructor(
    private sniper: SniperService,
    private formBuilder: FormBuilder,
    private setting: SettingService
  ) {}

  ngOnInit() {
    this.sniper.showSniper();
    this.setting.getCompanyInfo().subscribe(
      data => {
        this.companyInfo = data;
        this.sniper.hideSniper();
      },
      err => {
        this.sniper.hideSniper();
      }
    );

    this.initForm();
  }

  initForm() {
    this.formControls = this.formBuilder.group({
      fullName: [null, Validators.required],
      email: [null, Validators.required],
      phone: [null, Validators.required],
      content: [null, Validators.required]
    });
  }

  sendRequest(e) {
    this.submitted = true;
    this.formControls.markAllAsTouched();
    if (this.formControls.valid) {
      alert("Thành công!");
      this.formControls.reset();
    }
  }
}
