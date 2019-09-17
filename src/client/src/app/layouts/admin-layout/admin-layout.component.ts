import { Component, OnInit } from "@angular/core";
import { MenuItem } from "primeng/api";

@Component({
  selector: "app-admin-layout",
  templateUrl: "./admin-layout.component.html",
  styleUrls: ["./admin-layout.component.scss"]
})
export class AdminLayoutComponent implements OnInit {
  menuItems: MenuItem[];
  constructor() {
    this.menuItems = [];
  }

  ngOnInit() {
    this.menuItems = [
      {
        label: "Order",
        items: [
          {
            label: "Đơn đặt hàng",
            icon: "",
            routerLink: "order"
          }
        ]
      },
      {
        label: "Posts",
        items: [
          {
            label: "New Post",
            icon: "",
            routerLink: "post/add"
          },
          {
            label: "Posts",
            icon: "",
            routerLink: "post"
          }
        ]
      },
      {
        label: "Page",
        items: [
          {
            label: "New Page",
            icon: "",
            routerLink: "page/add"
          },
          {
            label: "Pages",
            icon: "",
            routerLink: "page"
          }
        ]
      },
      {
        label: "Price",
        items: [
          {
            label: "Bảng giá dịch vụ",
            icon: "",
            routerLink: "price"
          }
        ]
      },
      {
        label: "Service",
        items: [
          {
            label: "New Service",
            icon: "",
            routerLink: "service/add"
          },
          {
            label: "Service",
            icon: "",
            routerLink: "service"
          }
        ]
      },
      {
        label: "Method",
        items: [
          {
            label: "Phương án",
            icon: "",
            routerLink: "method"
          }
        ]
      },
      {
        label: "Discount",
        items: [
          {
            label: "Giảm giá",
            icon: "",
            routerLink: "discount"
          }
        ]
      },
      {
        label: "Setting",
        items: [
          {
            label: "Company",
            icon: "",
            routerLink: "setting/company"
          },
          {
            label: "Reasons",
            icon: "",
            routerLink: "setting/reasons"
          },
          {
            label: "Jumbotron",
            icon: "",
            routerLink: "setting/jumbotron"
          },
          {
            label: "Process Post",
            icon: "",
            routerLink: "setting/process"
          },
          {
            label: "Guide Post",
            icon: "",
            routerLink: "setting/guide"
          },
          {
            label: "Item combo",
            icon: "",
            routerLink: "setting/combo"
          }
        ]
      }
    ];
  }
}
