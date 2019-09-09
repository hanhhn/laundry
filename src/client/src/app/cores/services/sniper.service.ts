import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class SniperService {
  showSniper() {
    const element = document.querySelector(".blockUI");
    if (element) {
      element.setAttribute("style", "display: flex;");
    }
  }

  hideSniper() {
    const element = document.querySelector(".blockUI");
    if (element) {
      setTimeout(() => {
        element.setAttribute("style", "display: none;");
      }, 150);
    }
  }
}
