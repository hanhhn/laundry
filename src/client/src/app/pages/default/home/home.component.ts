import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.scss"]
})
export class HomeComponent implements OnInit {
  carousel = {
    title: "We love people who code  ",
    description:
      "Linux does not use extensions. It is up to the creator of the file to decide if he wants the name to have an extension.",
    strokedName: "Bảng giá",
    strokedLink: "/bang-gia",
    flatName: "Đặt ngay",
    flatLink: "/dat-ngay"
  };

  constructor() {}

  ngOnInit() {}
}
