import { Component } from '@angular/core';
import { Location } from 'src/app/location';
import { AddressesService } from '../addresses.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-add-address',
  templateUrl: './add-address.component.html',
  styleUrls: ['./add-address.component.css']
})
export class AddAddressComponent {


  address:Location ={
    userId: 2,
    latitude: '18.12345',
    longitude: '9.56789',
    landMark: '',
    pinCode: ''
  }
  constructor(private svc:AddressesService){}

 
  onInsert(form:NgForm){
//    this.address.pinCode= form.value.pincode;
//    this.address.landMark=form.value.landmark;
//    console.log(this.address);
//      this.svc.addAddress(this.address).subscribe((res) => {
//       console.log(res);
// });
}
  
}
