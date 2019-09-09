import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { AppComponent } from "./app.component";
import { AppRoutingModule } from "./app-routing.module";
import { HttpClientModule } from "@angular/common/http";
import { ItemService } from "./cores/services/item.service";
import { HttpService } from "./cores/services/http.service";
import { Http, HttpModule } from "@angular/http";
import { FormsModule } from "@angular/forms";
import { StorageService } from "./cores/services/storage.service";
import { SniperService } from "./cores/services/sniper.service";

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    HttpModule,
    FormsModule
  ],
  providers: [HttpService, StorageService, ItemService, SniperService],
  bootstrap: [AppComponent]
})
export class AppModule {}
