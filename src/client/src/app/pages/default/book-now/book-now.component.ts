import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MethodService } from "../../../cores/services/method.service";
import { BookNowService } from "./book-now.service";
import { Method } from "../../../cores/models/method.model";
import { AddressService } from "src/app/cores/services/address.service";
import { ItemService } from "../../../cores/services/item.service";
import { KeyValue } from "../../../cores/models/object.model";
import { TimeService } from "../../../cores/services/time.service";
import { StorageService } from "src/app/cores/services/storage.service";
import { MatDialog } from "@angular/material/dialog";

import {
  AddressUnit,
  Address,
  AddressRequest
} from "src/app/cores/models/address.model";
import { ConfirmComponent } from "src/app/components/confirm/confirm.component";

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
  isOneMoreAddress: boolean;

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
    private dialog: MatDialog,
    private formBuilder: FormBuilder,
    private methodService: MethodService,
    private bookNowService: BookNowService,
    private addressService: AddressService,
    private itemService: ItemService,
    private timeService: TimeService,
    private storageService: StorageService
  ) {
    // this.isShowFormContact = true;
    this.methods = [];
    this.isLinear = true;
    this.isMobile = false;
    this.isOneMoreAddress = false;
    this.provinces = [];
    this.districts = [];
    this.wards = [];
    this.addresses = [];
    this.deliveryTime = [];
    this.activeDay = [];
  }

  ngOnInit() {
    this.phone = this.storageService.getPhone();
    this.initServiceForm();
    this.initContactForm();

    this.loadTheWayClean();
    this.loadProvice();
    this.loadActiveDay();

    this.loadFullAddress(this.phone);
  }

  initContactForm() {
    this.contactFormGroup = this.formBuilder.group({
      id: [0],
      phone: [this.phone, Validators.required],
      fullName: [null, Validators.required],
      province: [null, Validators.required],
      district: [null, Validators.required],
      ward: [null, Validators.required],
      street: [null, Validators.required],
      dateOfReceipt: [null, Validators.required],
      hoursOfReceipt: [null, Validators.required]
    });
  }

  initServiceForm() {
    this.serviceFormGroup = this.formBuilder.group({
      method: [null, Validators.required],
      soft: [null, Validators.required],
      straight: [null, Validators.required],
      note: [null]
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
        this.storageService.savePhone(this.phone);

        this.loadFullAddress(this.phone);
      } else {
        this.addresses = [];
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

  onOneMoreAddress(e) {
    e.preventDefault();

    this.contactControls.id.patchValue(0);
    this.contactControls.fullName.patchValue(null);
    this.contactControls.province.patchValue(null);
    this.contactControls.district.patchValue(null);
    this.contactControls.ward.patchValue(null);
    this.contactControls.street.patchValue(null);

    this.addresses = [];
  }

  onCancelMoreAddress(e) {
    e.preventDefault();

    this.loadFullAddress(this.phone);
  }

  onConfirmOrder(e) {
    this.saveAddress();
  }

  onRemoveAdress(id) {
    const dialogRef = this.dialog.open(ConfirmComponent, {
      minWidth: "350px",
      data: {
        title: "Xóa!",
        message: "Bạn có chắc chắn muốn xóa địa chỉ?",
        noLabel: "Không",
        yesLabel: "Có"
      }
    });

    dialogRef.afterClosed().subscribe(data => {
      if (data) {
        this.addressService.delete(id).subscribe(address => {
          this.addresses = address ? address : [];
        });
      }
    });
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

      this.isOneMoreAddress = false;
      this.storageService.savePhone(request.phone);
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
    } else {
      this.addresses = [];
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
