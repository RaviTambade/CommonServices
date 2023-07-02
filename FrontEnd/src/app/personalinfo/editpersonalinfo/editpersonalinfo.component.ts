import { Component, OnInit } from '@angular/core';
import { Personalinfo } from '../personalinfo';
import { PersonalinfoService } from '../personalinfo.service';

@Component({
  selector: 'app-editpersonalinfo',
  templateUrl: './editpersonalinfo.component.html',
  styleUrls: ['./editpersonalinfo.component.css']
})
export class EditpersonalinfoComponent implements OnInit {
personalInfo:Personalinfo ;
personalInfoId:number;
constructor(private svc:PersonalinfoService){
  this.personalInfo={
    id: 1,
    aadharId: '',
    firstName: '',
    lastName: '',
    birthDate: '',
    gender: '',
    email: '',
    contactNumber: ''
  },
  this.personalInfoId=1;
}
  ngOnInit(): void {
  }
  updatePersonalInfo(){
    this.svc.updatePersonalInfo(this.personalInfoId,this.personalInfo).subscribe((response)=>{
      console.log(response)
     })
  }
  receivePersonalInfo($event:any){
  this.personalInfo=$event.personalInfo
  }
}
