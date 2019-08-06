import { Component, OnInit } from "@angular/core";
import { map } from "rxjs/operators";

@Component({
  selector: "app-guide",
  templateUrl: "./guide.component.html",
  styleUrls: ["./guide.component.scss"]
})
export class GuideComponent implements OnInit {
  steps = [
    {
      active: true,
      title: "Đặt dịch vụ với thao tác đơn giản",
      description: "Chọn địa điểm nhận đồ và thời gian"
    },
    {
      active: false,
      title: "Nhân viên sẽ đến tận nơi",
      description: "Nhân viên sẽ nhận đồ trong thời gian thích hợp nhất của bạn"
    },
    {
      active: false,
      title: "Theo dỏi quá trình giặt đồ",
      description: "Bạn có thể theo dỏi quần áo của mình đã giặt xong chưa"
    },
    {
      active: false,
      title: "Trả đồ",
      description: "Trả lại đồ tại nhà, tiết kiệm thời gian cho bạn"
    }
  ];

  constructor() {}

  ngOnInit() {}

  onMoved(item) {
    this.steps.map(x => {
      if (x === item) {
        x.active = true;
      } else {
        x.active = false;
      }
    });
  }
}
