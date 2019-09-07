import { Component, OnInit, ViewChild } from "@angular/core";
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
import { ConfirmComponent } from "src/app/components/confirm/confirm.component";
import {
  AddressUnit,
  Address,
  AddressRequest
} from "src/app/cores/models/address.model";
import { MatStepper } from "@angular/material";

@Component({
  selector: "app-book-now",
  templateUrl: "./book-now.component.html",
  styleUrls: ["./book-now.component.scss"]
})
export class BookNowComponent implements OnInit {
  isLinear: boolean;
  isMobile: boolean;
  isShowFullAddress: boolean;
  isShowOneMoreAddress: boolean;

  phone: string;
  address: Address;

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;

  serviceFormGroup: FormGroup;
  dateTimeFormGroup: FormGroup;
  contactFormGroup: FormGroup;

  methods: Method[];
  provinces: AddressUnit[];
  districts: AddressUnit[];
  wards: AddressUnit[];
  addresses: Address[];
  deliveryTime: Method[];
  activeDay: KeyValue[];

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
    return this.isShowFullAddress && this.addresses.length > 0;
  }

  get serviceControls() {
    return this.serviceFormGroup.controls;
  }

  get contactControls() {
    return this.contactFormGroup.controls;
  }

  get dateTimeControls() {
    return this.dateTimeFormGroup.controls;
  }

  @ViewChild("stepper", { static: false }) stepper: MatStepper;

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
    this.isShowFullAddress = false;
    this.methods = [];
    this.isLinear = true;
    this.isMobile = false;
    this.isShowOneMoreAddress = false;
    this.provinces = [];
    this.districts = [];
    this.wards = [];
    this.addresses = [];
    this.deliveryTime = [];
    this.activeDay = [];
  }

  ngOnInit() {
    this.firstFormGroup = this.formBuilder.group({
      valid: [false, Validators.requiredTrue]
    });

    this.secondFormGroup = this.formBuilder.group({
      valid: [false, Validators.requiredTrue]
    });

    this.phone = this.storageService.getPhone();
    if (this.phone && this.phone.length > 0) {
      this.loadFullAddress(this.phone);
    }

    this.initServiceForm();
    this.initContactForm();

    this.loadTheWayClean();
    this.loadProvice();
    this.loadActiveDay();
  }

  initServiceForm() {
    this.serviceFormGroup = this.formBuilder.group({
      method: [null, Validators.required],
      soft: [null, Validators.required],
      straight: [null, Validators.required],
      note: [null]
    });
  }

  initContactForm() {
    this.contactFormGroup = this.formBuilder.group({
      id: [0],
      phone: [this.phone, Validators.required],
      fullName: [null, Validators.required],
      province: [null, Validators.required],
      district: [null, Validators.required],
      ward: [null, Validators.required],
      street: [null, Validators.required]
    });

    this.dateTimeFormGroup = this.formBuilder.group({
      dateOfReceipt: [null, Validators.required],
      hoursOfReceipt: [null, Validators.required]
    });
  }

  onNextSecond(e) {
    e.preventDefault();

    this.serviceFormGroup.markAllAsTouched();
    this.firstFormGroup.controls.valid.setValue(this.serviceFormGroup.valid);
    if (this.firstFormGroup.valid) {
      this.stepper.next();
    }
  }

  onPhoneChanged(e) {
    if (e.target) {
      const length = e.target.value.length;
      this.phone = e.target.value;
      this.isShowOneMoreAddress = false;
      this.contactFormGroup.reset();

      if (10 <= length && length <= 11) {
        this.contactControls.phone.patchValue(this.phone);
        this.storageService.savePhone(this.phone);

        this.loadFullAddress(this.phone);
      } else {
        this.addresses = [];
      }

      if (length === 0) {
        this.storageService.removePhone();
      }
    }
  }

  onOneMoreAddress(e) {
    e.preventDefault();
    this.contactFormGroup.reset();
    this.contactControls.id.patchValue(0);
    this.contactControls.phone.patchValue(this.phone);
    this.isShowOneMoreAddress = true;
    this.isShowFullAddress = false;
  }

  onSaveAddress(e) {
    e.preventDefault();

    this.contactFormGroup.markAllAsTouched();

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
        this.setDefaultAddress(this.addresses[0]);
        this.isShowFullAddress = true;
        this.storageService.savePhone(request.phone);
      });
    }
  }

  onEditAdress(e, item: Address) {
    e.preventDefault();
    this.loadProvice();
    this.loadDistrict(item.provinceId);
    this.loadWard(item.districtId);

    this.contactControls.id.patchValue(item.id);
    this.contactControls.fullName.patchValue(item.fullName);
    this.contactControls.province.patchValue(item.provinceId);
    this.contactControls.district.patchValue(item.districtId);
    this.contactControls.ward.patchValue(item.wardId);
    this.contactControls.street.patchValue(item.street);

    this.isShowFullAddress = false;
    this.isShowOneMoreAddress = true;
    this.setDefaultAddress(this.addresses[0]);
  }

  onCancelMoreAddress(e) {
    e.preventDefault();
    this.isShowFullAddress = true;
    this.setDefaultAddress(this.address);
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
          this.setDefaultAddress(this.addresses[0]);
        });
      }
    });
  }

  onConfirmOrder(e) {
    this.contactFormGroup.markAllAsTouched();
    this.dateTimeFormGroup.markAllAsTouched();

    this.secondFormGroup.controls.valid.setValue(
      this.contactFormGroup.valid && this.dateTimeFormGroup.valid
    );

    if (this.secondFormGroup.valid) {
      console.log("ok");
    }
  }

  saveOrder() {}

  setDefaultAddress(item: Address) {
    if (item) {
      this.address = item;
      this.contactControls.id.patchValue(item.id);
      this.contactControls.fullName.patchValue(item.fullName);
      this.contactControls.province.patchValue(item.provinceId);
      this.contactControls.district.patchValue(item.districtId);
      this.contactControls.ward.patchValue(item.wardId);
      this.contactControls.street.patchValue(item.street);
    } else {
      if (this.addresses.length === 0) {
        this.address = null;
        this.contactControls.id.patchValue(this.phone);
        this.contactFormGroup.reset();
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

  loadTheWayClean() {
    this.methodService.getApplyMethod(0, 100).subscribe(data => {
      this.methods = data ? data.dataSource : [];
    });
  }

  loadActiveDay() {
    this.activeDay = this.timeService.getActiveTime();
  }

  loadFullAddress(phone: string) {
    if (phone && phone !== "" && phone.length > 8) {
      this.addressService.getFullAddress(phone).subscribe(data => {
        this.addresses = data ? data : [];

        if (this.addresses.length > 0) {
          this.setDefaultAddress(this.addresses[0]);
        }

        if (this.addresses.length > 0) {
          this.isShowFullAddress = true;
        } else {
          this.isShowFullAddress = false;
        }
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
