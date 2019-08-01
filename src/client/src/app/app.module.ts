import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { FlexLayoutModule } from "@angular/flex-layout";

import { AppComponent } from "./app.component";
import { AppRoutingModule } from "./app-routing.module";
import { DefaultModule } from "./pages/default/default.module";
import { AdminModule } from "./pages/admin/admin.module";
import { MaterialModule } from "./cores/material-module";
import { DefaultLayoutComponent } from "./layouts/default-layout/default-layout.component";
import { AdminLayoutComponent } from "./layouts/admin-layout/admin-layout.component";

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    AppRoutingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
