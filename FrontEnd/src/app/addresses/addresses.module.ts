import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddAddressComponent } from './add-address/add-address.component';
import { UpdateAddressComponent } from './update-address/update-address.component';



@NgModule({
  declarations: [
    AddAddressComponent,
    UpdateAddressComponent
  ],
  imports: [
    CommonModule
  ]
})
export class AddressesModule { }
