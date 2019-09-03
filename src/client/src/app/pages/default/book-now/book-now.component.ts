import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatStepper } from "@angular/material";
import { MethodService } from "../../../cores/services/method.service";
import { BookNowService } from "./book-now.service";
import { Method } from "../../../cores/models/method.model";

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
  dateFormGroup: FormGroup;

  isShowFormContact: boolean;

  methods: Method[];

  constructor(
    private formBuilder: FormBuilder,
    private methodService: MethodService,
    private bookNowService: BookNowService
  ) {
    this.isShowFormContact = true;
    this.methods = [];
  }

  ngOnInit() {
    this.serviceFormGroup = this.formBuilder.group({});
    this.contactFormGroup = this.formBuilder.group({});
    this.dateFormGroup = this.formBuilder.group({});
  }

  get getWayClean() {
    const way = this.bookNowService.getCleanMethod(this.methods);
    way.push(...this.bookNowService.getDryMethod(this.methods));
    return way;
  }

  get getWaySoft() {
    return this.bookNowService.getSoftMethod(this.methods);
  }

  get getWayStraight() {
    return this.bookNowService.getStraightMethod(this.methods);
  }

  onPhoneChanged(e) {
    if (e.target.value) {
      this.isShowFormContact = false;
    } else {
      this.isShowFormContact = true;
    }
  }

  loadWayClean() {
    this.methodService.getApplyMethod(0, 100).subscribe(
      data => {
        this.methods = data ? data.dataSource : [];
      },
      err => {
        alert("Xảy ra lỗi");
      }
    );
  }
}
