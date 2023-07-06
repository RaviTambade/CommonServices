import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './user';
import { Observable, Subject } from 'rxjs';



@Injectable({
  providedIn: 'root'
})
export class UserService {

  private userSubject: Subject<any[]> = new Subject<any[]>();
  constructor(private httpClient:HttpClient) {}

  addUser(user:User):Observable<any>{
    let url="http://localhost:5102/api/users/adduser"
    return this.httpClient.post<any>(url,user)
  }

  updateUser(id:number,user:User):Observable<any>{
    let url="http://localhost:5102/api/users/updateuser/" +id
    return this.httpClient.put<any>(url,user)
  }

  getUser(id:number):Observable<any>{
    let url="http://localhost:5102/api/users/" +id
    return this.httpClient.get<any>(url)
  }
  
  getallUser():Observable<any>{
    let url="http://localhost:5102/api/users/getall"
    this.httpClient.get<any[]>(url).subscribe(
      (response) => {
        this.userSubject.next(response);
      },
      (error) => {
        console.log('Error occurred:', error);
      }
    );
    return this.userSubject.asObservable();
  }

  removeUser(userId:number):Observable<any>{
    let url="http://localhost:5102/api/users/" +userId 
    return this.httpClient.delete<any>(url)
  }
}
