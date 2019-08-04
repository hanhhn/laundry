import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { BreakpointObserver, Breakpoints } from "@angular/cdk/layout";

@Component({
  selector: "app-book-now",
  templateUrl: "./book-now.component.html",
  styleUrls: ["./book-now.component.scss"]
})
export class BookNowComponent implements OnInit {
  isLinear = false;
  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  isMobile = false;

  constructor(
    private formBuilder: FormBuilder,
    breakpointObserver: BreakpointObserver
  ) {
    breakpointObserver
      .observe([Breakpoints.XSmall])
      .subscribe(result => {
        this.isMobile = result.matches;
        console.log(result);
      });
  }

  ngOnInit() {
    this.firstFormGroup = this.formBuilder.group({
      firstCtrl: ["", Validators.required]
    });
    this.secondFormGroup = this.formBuilder.group({
      secondCtrl: ["", Validators.required]
    });
  }
}
