import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatStepper } from "@angular/material";
import { MethodService } from "../../../cores/services/method.service";
import { BookNowService } from "./book-now.service";
import { Method } from "../../../cores/models/method.model";
import { AddressService } from "src/app/cores/services/address.service";
import {
  AddressUnit,
  Address,
  AddressRequest
} from "src/app/cores/models/address.model";
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
  deliveryTime: Method[];
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
    this.deliveryTime = [];
    this.activeDay = [];
  }

  ngOnInit() {
    this.initForm();
    this.loadTheWayClean();
    this.loadProvice();
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
      id: [0],
      phone: [null, Validators.required],
      fullName: [null, Validators.required],
      province: [null, Validators.required],
      district: [null, Validators.required],
      ward: [null, Validators.required],
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

  get getDeliveryTime() {
    return this.bookNowService.getDeliveryMethod(this.methods);
  }

  get alreadyExists() {
    return this.addresses && this.addresses.length > 0;
  }

  get serviceControls() {
    return this.serviceFormGroup.controls;
  }

  get contactControls() {
    return this.contactFormGroup.controls;
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

  onConfirmOrder(e) {
    this.saveAddress();
  }

  saveAddress() {
    if (this.contactFormGroup.valid) {
      const request = new AddressRequest();
      request.id = this.contactControls.id.value;
      request.phone = this.contactControls.phone.value;
      request.fullName = this.contactControls.fullName.value;
      request.provinceId = this.contactControls.province.value;
      request.districtId = this.contactControls.district.value;
      request.wardId = this.contactControls.ward.value;
      request.street = this.contactControls.street.value;

      this.addressService.save(request).subscribe(data => {
        this.addresses = data ? data : [];
      });
    }
  }

  saveOrder() {}

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
