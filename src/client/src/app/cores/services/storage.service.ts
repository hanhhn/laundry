import {
  TOKEN_KEY,
  REFRESH_TOKEN_KEY,
  PHONE_TOKEN_KEY
} from "./../../app.config";

export class StorageService {
  saveLoginToken(token, refreshToken) {
    localStorage.setItem(TOKEN_KEY, token);
    localStorage.setItem(REFRESH_TOKEN_KEY, refreshToken);
  }

  savePhone(phone) {
    localStorage.setItem(PHONE_TOKEN_KEY, phone);
  }

  getPhone() {
    return localStorage.getItem(PHONE_TOKEN_KEY);
  }

  getToken() {
    return localStorage.getItem(TOKEN_KEY);
  }

  clear() {
    return localStorage.clear();
  }
}
