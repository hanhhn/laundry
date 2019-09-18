import { Component, OnInit } from "@angular/core";
import { Company, Reason } from "../../../cores/models/setting.model";
import { DomSanitizer, SafeUrl } from "@angular/platform-browser";
import { SettingService } from "src/app/cores/services/setting.service";
import { SniperService } from "../../../cores/services/sniper.service";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ContactService } from "src/app/cores/services/contact.service";
import { ContactRequest } from "src/app/cores/models/contact.model";
import { MatDialog } from "@angular/material";
import { ConfirmComponent } from "src/app/components/confirm/confirm.component";

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
    private dialog: MatDialog,
    private formBuilder: FormBuilder,
    private setting: SettingService,
    private contactService: ContactService
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
      const request = new ContactRequest();
      request.fullName = this.controls.fullName.value;
      request.email = this.controls.email.value;
      request.phone = this.controls.phone.value;
      request.content = this.controls.content.value;
      this.contactService.save(request).subscribe(data => {
        if (data) {
          const dialogRef = this.dialog.open(ConfirmComponent, {
            minWidth: "350px",
            data: {
              title: "Thông báo!",
              message:
                "Gửi yêu cầu thành công, chúng tôi sẽ sớm liên hệ với bạn!",
              yesLabel: "OK"
            }
          });

          dialogRef.afterClosed().subscribe(() => {
            this.formControls.reset();
          });
        }
      });
    }
  }
}
