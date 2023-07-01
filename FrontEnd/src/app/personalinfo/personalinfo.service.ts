import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Personalinfo } from './personalinfo';

@Injectable({
  providedIn: 'root'
})
export class PersonalinfoService {
  constructor(private httpClient:HttpClient) {}

  addPersonalInfo(personalInfo:Personalinfo):Observable<any>{
    let url="http://localhost:5102/api/peoples/addpeople"
    return this.httpClient.post<any>(url,personalInfo)
  }

  updatePersonalInfo(id:number,personalInfo:Personalinfo):Observable<any>{
    let url="http://localhost:5102/api/peoples/updatepeople" +id
    return this.httpClient.post<any>(url,personalInfo)
  }
}
