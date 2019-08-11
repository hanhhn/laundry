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

  nacyUrl = "../../../../assets/nacy.jpg";

  items = [
    {
      imageUrl: this.nacyUrl,
      name: "Áo/Quần bình thường",
      rate: "12"
    },
    {
      imageUrl: this.nacyUrl,
      name: "Vest",
      rate: "12"
    },
    {
      imageUrl: this.nacyUrl,
      name: "Áo dài",
      rate: "12"
    },
    {
      imageUrl: this.nacyUrl,
      name: "Ba lô/Túi Xách ",
      rate: "12"
    },
    {
      imageUrl: this.nacyUrl,
      name: "Thú nhồi bông",
      rate: "12"
    },
    {
      imageUrl: this.nacyUrl,
      name: "Chất liệu khác ",
      rate: "12"
    }
  ];

  itemFormGroup: FormGroup;
  serviceFormGroup: FormGroup;
  contactFormGroup: FormGroup;

  isShowFormContact: boolean;

  constructor(
    private formBuilder: FormBuilder,
    breakpointObserver: BreakpointObserver
  ) {
    breakpointObserver.observe([Breakpoints.XSmall]).subscribe(result => {
      this.isMobile = result.matches;
      console.log(result);
    });

    this.isShowFormContact = true;
  }

  ngOnInit() {
    this.itemFormGroup = this.formBuilder.group({});
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
