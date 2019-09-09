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
import { OrdersService } from "../../../cores/services/orders.service";
import { OrderRequest, Order } from "../../../cores/models/orders.model";
import {
  AddressUnit,
  Address,
  AddressRequest
} from "src/app/cores/models/address.model";
import {
  MatStepper,
  MatSelectChange,
  MatOption,
  MatRadioChange
} from "@angular/material";
import { SniperService } from "../../../cores/services/sniper.service";

const thankYou = "./../../../../assets/thanks-you-for-your-order.png";

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
  thanksYou = thankYou;

  phone: string;
  address: Address;
  hoursOfReceipt: string;

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

  order: Order;
  method: string;
  soft: string;
  straight: string;

  completed: boolean;

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
    private sniper: SniperService,
    private dialog: MatDialog,
    private formBuilder: FormBuilder,
    private methodService: MethodService,
    private bookNowService: BookNowService,
    private addressService: AddressService,
    private itemService: ItemService,
    private timeService: TimeService,
    private ordersService: OrdersService,
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
    this.completed = false;
  }

  ngOnInit() {
    this.sniper.showSniper();

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

    this.sniper.hideSniper();
  }

  initServiceForm() {
    this.serviceFormGroup = this.formBuilder.group({
      method: [null, Validators.required],
      soft: [null, Validators.required],
      straight: [null],
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
    this.sniper.showSniper();
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

      this.addressService.save(request).subscribe(
        data => {
          this.addresses = data ? data : [];
          this.setDefaultAddress(this.addresses[0]);
          this.isShowFullAddress = true;
          this.storageService.savePhone(request.phone);

          this.sniper.hideSniper();
        },
        err => {
          this.sniper.hideSniper();
        }
      );
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

    this.sniper.showSniper();
    dialogRef.afterClosed().subscribe(data => {
      if (data) {
        this.addressService.delete(id).subscribe(
          address => {
            this.addresses = address ? address : [];
            this.setDefaultAddress(this.addresses[0]);
            this.sniper.hideSniper();
          },
          err => {
            this.sniper.hideSniper();
          }
        );
      }
    });
  }

  onConfirmOrder(e) {
    this.contactFormGroup.markAllAsTouched();
    this.dateTimeFormGroup.markAllAsTouched();

    this.secondFormGroup.controls.valid.setValue(
      this.contactFormGroup.valid && this.dateTimeFormGroup.valid
    );

    if (this.secondFormGroup.valid && this.firstFormGroup.valid) {
      this.saveOrder();
    }
  }

  saveOrder() {
    this.sniper.showSniper();
    const request = new OrderRequest();
    request.methodId = this.serviceControls.method.value;
    request.softId = this.serviceControls.soft.value;
    const straightId = this.serviceControls.straight.value;
    request.straightId = straightId ? straightId : 0;
    request.note = this.serviceControls.note.value;

    request.addressId = this.contactControls.id.value;
    request.phone = this.contactControls.phone.value;
    request.fullName = this.contactControls.fullName.value;
    request.provinceId = this.contactControls.province.value;
    request.districtId = this.contactControls.district.value;
    request.wardId = this.contactControls.ward.value;
    request.street = this.contactControls.street.value;

    request.dateOfReceipt = this.dateTimeControls.dateOfReceipt.value;
    request.deliveryId = this.dateTimeControls.hoursOfReceipt.value;
    request.hoursOfReceipt = this.hoursOfReceipt;

    this.ordersService.saveOrder(request).subscribe(
      data => {
        if (data) {
          this.order = data;
          this.order.method = this.method;
          this.order.soft = this.soft;
          this.order.straight = this.straight;

          this.completed = true;
          this.stepper.next();

          this.firstFormGroup.reset();
          this.secondFormGroup.reset();
          this.serviceFormGroup.reset();
          this.contactFormGroup.reset();
        } else {
          this.dialog.open(ConfirmComponent, {
            minWidth: "350px",
            data: {
              title: "Thông báo!",
              message:
                "Xảy xa lỗi trong quá trình đặt dịch vụ, xin vui lòng đăng ký lại sau!",
              yesLabel: "OK"
            }
          });
        }

        this.sniper.hideSniper();
      },
      err => {
        this.sniper.hideSniper();

        this.dialog.open(ConfirmComponent, {
          minWidth: "350px",
          data: {
            title: "Thông báo!",
            message:
              "Xảy xa lỗi trong quá trình đặt dịch vụ, xin vui lòng đăng ký lại sau!",
            yesLabel: "OK"
          }
        });
      }
    );
  }

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
        this.isShowFullAddress = false;
        this.isShowOneMoreAddress = false;
        this.contactControls.id.patchValue(this.phone);
        this.contactFormGroup.reset();
      }
    }
  }

  onDeliveryTimeSelected(event: MatSelectChange) {
    const data = {
      text: (event.source.selected as MatOption).viewValue,
      value: event.source.value
    };
    this.hoursOfReceipt = data.text;
  }

  onMethodChanged(event: MatRadioChange) {
    const item = this.methods.find(x => x.id === event.source.value);
    if (item) {
      this.method = item.name;
    }
  }

  onSoftChanged(event: MatRadioChange) {
    const item = this.methods.find(x => x.id === event.source.value);
    if (item) {
      this.soft = item.name;
    }
  }

  onStraightChanged(event: MatRadioChange) {
    const item = this.methods.find(x => x.id === event.source.value);
    if (item) {
      this.straight = item.name;
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
      this.sniper.showSniper();
      this.addressService.getFullAddress(phone).subscribe(
        data => {
          this.addresses = data ? data : [];

          if (this.addresses.length > 0) {
            this.setDefaultAddress(this.addresses[0]);
          }

          if (this.addresses.length > 0) {
            this.isShowFullAddress = true;
          } else {
            this.isShowFullAddress = false;
          }
          this.sniper.hideSniper();
        },
        err => {
          this.sniper.showSniper();
        }
      );
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
