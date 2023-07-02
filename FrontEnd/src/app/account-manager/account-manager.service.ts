import { Injectable } from '@angular/core';
import { Account } from '../Account';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountManagerService {

  constructor(private http:HttpClient) { }

  addAccount(acct:Account):Observable<any>{
    let url ="http://localhost:5053/bankaccounts/account";
    return this.http.post<Account>(url,acct);
  }
}