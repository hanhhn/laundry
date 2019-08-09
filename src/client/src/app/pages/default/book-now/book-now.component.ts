import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { BreakpointObserver, Breakpoints } from "@angular/cdk/layout";

@Component({
  selector: "app-book-now",
  templateUrl: "./book-now.component.html",
  styleUrls: ["./book-now.component.scss"]
})
export class BookNowComponent implements OnInit {
  isLinear = true;
  isMobile = false;

  contactFormGroup: FormGroup;
  serviceFormGroup: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    breakpointObserver: BreakpointObserver
  ) {
    breakpointObserver.observe([Breakpoints.XSmall]).subscribe(result => {
      this.isMobile = result.matches;
      console.log(result);
    });
  }

  ngOnInit() {
    this.contactFormGroup = this.formBuilder.group({});
    this.serviceFormGroup = this.formBuilder.group({});
  }
}
