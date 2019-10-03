import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { ContactComponent } from "./contact.component";
import { FlexLayoutModule } from "@angular/flex-layout";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ContactService } from "src/app/cores/services/contact.service";
import { ConfirmModule } from "src/app/components/confirm/confirm.module";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatButtonModule } from "@angular/material/button";
import { MatInputModule } from "@angular/material/input";
import { MatIconModule } from "@angular/material/icon";
import { MatDialogModule } from "@angular/material/dialog";

const routes: Routes = [
  {
    path: "",
    component: ContactComponent
  }
];

@NgModule({
  declarations: [ContactComponent],
  imports: [
    CommonModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule,
    ConfirmModule,
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    MatIconModule,
    MatDialogModule,
    RouterModule.forChild(routes)
  ],
  providers: [ContactService]
})
export class ContactModule {}
