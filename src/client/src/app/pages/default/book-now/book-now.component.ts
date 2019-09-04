import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatStepper } from "@angular/material";
import { MethodService } from "../../../cores/services/method.service";
import { BookNowService } from "./book-now.service";
import { Method } from "../../../cores/models/method.model";
import { AddressService } from "src/app/cores/services/address.service";
import { AddressUnit, Address } from "src/app/cores/models/address.model";

@Component({
  selector: "app-book-now",
  templateUrl: "./book-now.component.html",
  styleUrls: ["./book-now.component.scss"]
})
export class BookNowComponent implements OnInit {
  isLinear: boolean;
  isMobile: boolean;
  isShowFormContact: boolean;
  phone: string;

  serviceFormGroup: FormGroup;
  contactFormGroup: FormGroup;
  dateFormGroup: FormGroup;

  methods: Method[];
  provinces: AddressUnit[];
  districts: AddressUnit[];
  wards: AddressUnit[];
  addresses: Address[];

  constructor(
    private formBuilder: FormBuilder,
    private methodService: MethodService,
    private bookNowService: BookNowService,
    private addressService: AddressService
  ) {
    this.isShowFormContact = true;
    this.methods = [];
    this.isLinear = true;
    this.isMobile = false;
    this.provinces = [];
    this.districts = [];
    this.wards = [];
    this.addresses = [];
  }

  ngOnInit() {
    this.loadTheWayClean();
    this.loadProvice();

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

  onProvinceChanged(id) {
    this.loadDistrict(id);
    this.wards = [];
  }

  onDistrictChanged(id) {
    this.loadWard(id);
  }

  loadTheWayClean() {
    this.methodService.getApplyMethod(0, 100).subscribe(
      data => {
        this.methods = data ? data.dataSource : [];
      },
      err => {
        alert("Xảy ra lỗi");
      }
    );
  }

  loadFullAddress(phone: string) {
    this.addressService.getFullAddress(phone).subscribe(data => {
      this.addresses = data ? data : [];
    });
  }

  loadProvice() {
    this.addressService.getProvince().subscribe(data => {
      this.provinces = data ? data : [];
    });
    this.districts = [];
    this.wards = [];
  }

  loadDistrict(id: number) {
    this.addressService.getDistrict(id).subscribe(data => {
      this.districts = data ? data : [];
    });
    this.wards = [];
  }

  loadWard(id: number) {
    this.addressService.getWard(id).subscribe(data => {
      this.wards = data ? data : [];
    });
  }
}
