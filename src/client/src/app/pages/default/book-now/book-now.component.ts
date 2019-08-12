import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: "app-book-now",
  templateUrl: "./book-now.component.html",
  styleUrls: ["./book-now.component.scss"]
})
export class BookNowComponent implements OnInit {
  isLinear = true;
  isMobile = false;

  serviceFormGroup: FormGroup;
  contactFormGroup: FormGroup;

  isShowFormContact: boolean;

  constructor(private formBuilder: FormBuilder) {
    this.isShowFormContact = true;
  }

  ngOnInit() {
    this.serviceFormGroup = this.formBuilder.group({});
    this.contactFormGroup = this.formBuilder.group({});
  }

  onItemChecked(checked: boolean, id: string) {}

  onPhoneChanged(e) {
    if (e.target.value) {
      this.isShowFormContact = false;
    } else {
      this.isShowFormContact = true;
    }
  }
}
