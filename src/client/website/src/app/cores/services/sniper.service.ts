import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class SniperService {
  showSniper() {
    const element = document.querySelector(".blockUI");
    if (element) {
      const style = element.getAttribute("style");
      if (style !== "display: flex;") {
        element.setAttribute("style", "display: flex;");
      }
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
