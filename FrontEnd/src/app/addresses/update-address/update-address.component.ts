import { Component } from '@angular/core';
import { AddressesService } from '../addresses.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-update-address',
  templateUrl: './update-address.component.html',
  styleUrls: ['./update-address.component.css']
})
export class UpdateAddressComponent  {
 
  Address:any={
    "pinCode":'',
    "landMark":'',
    
  }

  constructor(private svc:AddressesService){}

 
  onUpdate(form:NgForm){

    this.Address.pinCode=form.value.pincode;
    this.Address.landMark=form.value.landmark;
    console.log(this.Address);
   
  }

}
