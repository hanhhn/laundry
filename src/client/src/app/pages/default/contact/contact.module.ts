import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { ContactComponent } from "./contact.component";
import { FlexLayoutModule } from "@angular/flex-layout";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import {
  MatFormFieldModule,
  MatButtonModule,
  MatInputModule,
  MatIconModule
} from "@angular/material";

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
    MatFormFieldModule,
    MatButtonModule,
    MatInputModule,
    MatIconModule,
    RouterModule.forChild(routes)
  ]
})
export class ContactModule {}
