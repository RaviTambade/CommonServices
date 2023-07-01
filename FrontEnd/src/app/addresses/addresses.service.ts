import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Addresses } from '../addresses';

@Injectable({
  providedIn: 'root'
})
export class AddressesService {

  constructor(private http:HttpClient) { }

  updateAddress(address:Addresses){
    let url ="http://localhost:5102/api/addresses/";
    return this.http.put(url,address);
  }

  addAddress(address:Addresses){
    let url ="http://localhost:5102/api/addresses/";
    return this.http.post(url,address);
  }
}
