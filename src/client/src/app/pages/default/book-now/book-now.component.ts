import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatStepper } from "@angular/material";
import { MethodService } from "../../../cores/services/method.service";
import { BookNowService } from "./book-now.service";
import { Method } from "../../../cores/models/method.model";
import { AddressService } from "src/app/cores/services/address.service";
import { AddressUnit, Address } from "src/app/cores/models/address.model";
import { Item } from "../../../cores/models/item.model";
import { ItemService } from "../../../cores/services/item.service";
import { KeyValue } from "../../../cores/models/object.model";
import { TimeService } from "../../../cores/services/time.service";

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

  methods: Method[];
  provinces: AddressUnit[];
  districts: AddressUnit[];
  wards: AddressUnit[];
  addresses: Address[];
  transportTime: Item[];
  activeDay: KeyValue[];

  constructor(
    private formBuilder: FormBuilder,
    private methodService: MethodService,
    private bookNowService: BookNowService,
    private addressService: AddressService,
    private itemService: ItemService,
    private timeService: TimeService
  ) {
    // this.isShowFormContact = true;
    this.methods = [];
    this.isLinear = true;
    this.isMobile = false;
    this.provinces = [];
    this.districts = [];
    this.wards = [];
    this.addresses = [];
    this.transportTime = [];
    this.activeDay = [];
  }

  ngOnInit() {
    this.initForm();
    this.loadTheWayClean();
    this.loadProvice();
    this.loadTransportTime();
    this.loadActiveDay();
    this.loadFullAddress(this.phone);
  }

  initForm() {
    this.serviceFormGroup = this.formBuilder.group({
      method: [null, Validators.required],
      soft: [null, Validators.required],
      straight: [null, Validators.required],
      note: [null]
    });

    this.contactFormGroup = this.formBuilder.group({
      phone: [null, Validators.required],
      addressId: [null, Validators.required],
      fullName: [null, Validators.required],
      province: [null, Validators.required],
      district: [null, Validators.required],
      wards: [null, Validators.required],
      street: [null, Validators.required],
      dateOfReceipt: [null, Validators.required],
      hoursOfReceipt: [null, Validators.required]
    });
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

  get alreadyExists() {
    return this.addresses && this.addresses.length > 0;
  }

  onPhoneChanged(e) {
    if (e.target && e.target.value) {
      const length = e.target.value.length;
      this.phone = e.target.value;

      if (10 <= length && length <= 11) {
        this.loadFullAddress(this.phone);
      }
    }
  }

  onProvinceChanged(id) {
    this.loadDistrict(id);
    this.wards = [];
  }

  onDistrictChanged(id) {
    this.loadWard(id);
  }

  onSaveAddress() {}

  onSaveOrder() {}

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

  loadTransportTime() {
    this.itemService.getTransport(0, 10).subscribe(data => {
      this.transportTime = data ? data.dataSource : [];
    });
  }

  loadActiveDay() {
    this.activeDay = this.timeService.getActiveTime();
  }

  loadFullAddress(phone: string) {
    if (phone && phone !== "") {
      this.addressService.getFullAddress(phone).subscribe(data => {
        this.addresses = data ? data : [];
      });
    }
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
