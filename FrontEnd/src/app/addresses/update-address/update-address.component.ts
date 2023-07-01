import { Component } from '@angular/core';
import { AddressesService } from '../addresses.service';
import { NgForm } from '@angular/forms';
import { Addresses } from 'src/app/addresses';

@Component({
  selector: 'app-update-address',
  templateUrl: './update-address.component.html',
  styleUrls: ['./update-address.component.css']
})
export class UpdateAddressComponent  {
 
  address:Addresses={
    personId: 0,
    latitude: '',
    langitude: '',
    landMark: '',
    pinCode: ''
  }

  status : boolean | undefined;

  constructor(private svc:AddressesService){}

 
  onUpdate(form:any){
     this.svc.updateAddress(form).subscribe((response)=>{
    //  this.status=response;
    //  console.log(status);
     })
   

     
 
   
  }

}
