import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Personalinfo } from './personalinfo';

@Injectable({
  providedIn: 'root'
})
export class PersonalinfoService {
  private personalInfoSubject: Subject<any[]> = new Subject<any[]>();
  constructor(private httpClient:HttpClient) {}

  addPersonalInfo(personalInfo:Personalinfo):Observable<any>{
    let url="http://localhost:5102/api/peoples/addpeople"
    return this.httpClient.post<any>(url,personalInfo)
  }

  updatePersonalInfo(id:number,personalInfo:Personalinfo):Observable<any>{
    let url="http://localhost:5102/api/peoples/updatepeople/" +id
    return this.httpClient.put<any>(url,personalInfo)
  }

  getPersonalInfo(id:number):Observable<any>{
let url="http://localhost:5102/api/peoples/" +id
return this.httpClient.get<any>(url)
  }
  
  getallPersonalInfo():Observable<any>{
    let url="http://localhost:5102/api/peoples/getall"
    this.httpClient.get<any[]>(url).subscribe(
      (response) => {
        this.personalInfoSubject.next(response);
      },
      (error) => {
        console.log('Error occurred:', error);
      }
    );
    return this.personalInfoSubject.asObservable();
  }

  removePersonalInfo(peopleId:number):Observable<any>{
    let url="http://localhost:5102/api/peoples/" +peopleId 
    return this.httpClient.delete<any>(url)
  }
  }
