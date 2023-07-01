import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AddressesService {

  constructor(private http:HttpClient) { }

  updateAddress(address:any){
    let url ="http://localhost:";
    return this.http.post(url,address);
  }
}
