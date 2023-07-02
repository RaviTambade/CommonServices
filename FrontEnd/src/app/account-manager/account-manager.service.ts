import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Account } from './account';

@Injectable({
  providedIn: 'root'
})
export class AccountManagerService {

  constructor(private http:HttpClient) { }


 public  UpdateAccount(account : Account){
    let url="http://localhost:5053/bankaccounts/account"
    return this.http.put<any>(url,account);
  }
}
