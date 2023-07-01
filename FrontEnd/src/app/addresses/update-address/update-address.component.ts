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
    personId: 3,
    latitude: '18.535317',
    langitude: '9.595334',
    landMark: '',
    pinCode: ''
  }

  status: boolean | undefined;

  constructor(private svc:AddressesService){}

 
  onUpdate(form:any){
     this.svc.updateAddress(form).subscribe((res) => {
      this.status = res;
      console.log(res);
});
}

}
