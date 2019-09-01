import { Injectable } from "@angular/core";
import { IMGUR_API } from "./../../app.config";


@Injectable()
export class ImageService {
  uploadToImgur(file, resolve, reject) {
    return new Promise(() => {
      const xhr = new XMLHttpRequest();
      xhr.open("POST", IMGUR_API);
      xhr.setRequestHeader("Authorization", "Client-ID 3aae9208fae2a49");
      const data = new FormData();
      data.append("image", file);
      xhr.send(data);
      xhr.addEventListener("load", () => {
        const response = JSON.parse(xhr.responseText);
        resolve(response);
      });
      xhr.addEventListener("error", () => {
        const error = JSON.parse(xhr.responseText);
        reject(error);
      });
    });
  }
}
