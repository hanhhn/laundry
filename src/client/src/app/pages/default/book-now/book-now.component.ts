import { Component, OnInit, ViewChild } from "@angular/core";
import { FormBuilder, FormGroup, Validators, FormArray } from "@angular/forms";
import { MethodService } from "../../../cores/services/method.service";
import { Method } from "../../../cores/models/method.model";
import { AddressService } from "src/app/cores/services/address.service";
import { KeyValue } from "../../../cores/models/object.model";
import { TimeService } from "../../../cores/services/time.service";
import { StorageService } from "src/app/cores/services/storage.service";
import { MatDialog } from "@angular/material/dialog";
import { ConfirmComponent } from "src/app/components/confirm/confirm.component";
import { OrdersService } from "../../../cores/services/orders.service";
import { OrderRequest, Order } from "../../../cores/models/orders.model";
import { SniperService } from "../../../cores/services/sniper.service";
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

const thankYou = "./../../../../assets/thanks-you-for-your-order.png";

const METHOD = {
  CLEAN: "Clean",
  DELIVERY: "Delivery",
  OTHER: "Other"
};

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

  serviceFormGroup: FormGroup;
  contactFormGroup: FormGroup;

  methods: Method[];
  provinces: AddressUnit[];
  districts: AddressUnit[];
  wards: AddressUnit[];
  addresses: Address[];
  deliveryTime: Method[];
  activeDay: KeyValue[];

  order: Order;
  clean: string;
  options: string[] = [];

  completed: boolean;

  get getWayClean() {
    return this.methods.filter(x => x.type === METHOD.CLEAN);
  }

  get getOptions() {
    return this.methods.filter(x => x.type === METHOD.OTHER);
  }

  get getDeliveryTime() {
    return this.methods.filter(x => x.type === METHOD.DELIVERY);
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

  get optionControls(): FormArray {
    return this.serviceFormGroup.get("options") as FormArray;
  }

  get deliveryControls() {
    return (this.contactFormGroup.get("delivery") as FormGroup).controls;
  }

  get addressControls() {
    return (this.contactFormGroup.get("address") as FormGroup).controls;
  }

  @ViewChild("stepper", { static: false }) stepper: MatStepper;

  constructor(
    private sniper: SniperService,
    private dialog: MatDialog,
    private formBuilder: FormBuilder,
    private methodService: MethodService,
    private addressService: AddressService,
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
    this.phone = this.storageService.getPhone();

    this.initServiceForm();
    this.initContactForm();

    if (this.phone && this.phone.length > 0) {
      this.loadFullAddress(this.phone);
    }

    this.loadTheWayClean();
    this.loadProvice();
    this.loadActiveDay();

    this.sniper.hideSniper();
  }

  initServiceForm() {
    this.serviceFormGroup = this.formBuilder.group({
      clean: [null, Validators.required],
      options: this.formBuilder.array([]),
      note: [null]
    });
  }

  initContactForm() {
    this.contactFormGroup = this.formBuilder.group({
      phone: [this.phone, Validators.required],
      delivery: this.formBuilder.group({
        dateOfReceipt: [null, Validators.required],
        hoursOfReceipt: [null, Validators.required]
      }),
      address: this.formBuilder.group({
        id: [0],
        fullName: [null, Validators.required],
        province: [null, Validators.required],
        district: [null, Validators.required],
        ward: [null, Validators.required],
        street: [null, Validators.required]
      })
    });
  }

  onNextSecond(e) {
    e.preventDefault();

    this.serviceFormGroup.markAllAsTouched();
    if (this.serviceFormGroup.valid) {
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
    this.addressControls.id.patchValue(0);
    this.contactControls.phone.patchValue(this.phone);
    this.isShowOneMoreAddress = true;
    this.isShowFullAddress = false;
  }

  onSaveAddress(e) {
    e.preventDefault();

    const addressFormGroup = this.contactFormGroup.get("address") as FormGroup;
    addressFormGroup.markAllAsTouched();

    if (addressFormGroup.valid) {
      const request = new AddressRequest();
      request.id = this.addressControls.id.value;
      request.phone = this.contactControls.phone.value;
      request.fullName = this.addressControls.fullName.value;
      request.provinceId = this.addressControls.province.value;
      request.districtId = this.addressControls.district.value;
      request.wardId = this.addressControls.ward.value;
      request.street = this.addressControls.street.value;

      this.sniper.showSniper();
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

    this.addressControls.id.patchValue(item.id);
    this.addressControls.fullName.patchValue(item.fullName);
    this.addressControls.province.patchValue(item.provinceId);
    this.addressControls.district.patchValue(item.districtId);
    this.addressControls.ward.patchValue(item.wardId);
    this.addressControls.street.patchValue(item.street);

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

    if (this.serviceFormGroup.valid && this.contactFormGroup.valid) {
      this.saveOrder();
    }
  }

  saveOrder() {
    this.sniper.showSniper();
    const request = new OrderRequest();
    request.cleanId = this.serviceControls.clean.value;
    request.note = this.serviceControls.note.value;
    request.optionsId = [];
    this.optionControls.controls.map((value, index) => {
      if (value) {
        const item = this.getOptions[index];
        request.optionsId.push(item.id);
        this.options.push(item.name);
      }
    });

    request.addressId = this.addressControls.id.value;
    request.phone = this.contactControls.phone.value;
    request.fullName = this.addressControls.fullName.value;
    request.provinceId = this.addressControls.province.value;
    request.districtId = this.addressControls.district.value;
    request.wardId = this.addressControls.ward.value;
    request.street = this.addressControls.street.value;

    request.dateOfReceipt = this.deliveryControls.dateOfReceipt.value;
    request.deliveryId = this.deliveryControls.hoursOfReceipt.value;
    request.hoursOfReceipt = this.hoursOfReceipt;

    this.ordersService.saveOrder(request).subscribe(
      data => {
        if (data) {
          this.clean = this.methods.find(x => x.id === request.cleanId).name;
          console.log(this.clean);
          console.log(this.options);
          this.order = data;
          this.completed = true;
          this.stepper.next();
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
      this.addressControls.id.patchValue(item.id);
      this.addressControls.fullName.patchValue(item.fullName);
      this.addressControls.province.patchValue(item.provinceId);
      this.addressControls.district.patchValue(item.districtId);
      this.addressControls.ward.patchValue(item.wardId);
      this.addressControls.street.patchValue(item.street);
    } else {
      if (this.addresses.length === 0) {
        this.address = null;
        this.isShowFullAddress = false;
        this.isShowOneMoreAddress = false;
        this.addressControls.id.patchValue(0);
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

  onCleanChanged(event: MatRadioChange) {
    const item = this.methods.find(x => x.id === event.source.value);
    if (item) {
      this.clean = item.name;
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

      this.getOptions.map((value, index) => {
        this.optionControls.controls.push(this.formBuilder.control(false));
      });
    });
  }

  loadActiveDay() {
    this.timeService.getActiveTime().subscribe(data => {
      this.activeDay = data;
    });
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
