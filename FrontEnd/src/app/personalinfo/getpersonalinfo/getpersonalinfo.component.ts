import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Personalinfo } from '../personalinfo';
import { PersonalinfoService } from '../personalinfo.service';

@Component({
  selector: 'app-getpersonalinfo',
  templateUrl: './getpersonalinfo.component.html',
  styleUrls: ['./getpersonalinfo.component.css']
})
export class GetpersonalinfoComponent implements OnInit {
personalInfo:Personalinfo;
@Input() personalInfoId:number;
@Output() sendPersonalInfo=new EventEmitter();
constructor(private svc :PersonalinfoService){
  this.personalInfo={
    id: 0,
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
    this.svc.getPersonalInfo(this.personalInfoId).subscribe((response)=>{
      this.personalInfo=response
      console.log(response)
      this.sendPersonalInfo.emit({personalInfo:this.personalInfo})
    })
}
getPersonalInfoById(id:any){
  this.svc.getPersonalInfo(id).subscribe((response)=>{
    this.personalInfo=response
    console.log(response)
    this.sendPersonalInfo.emit({personalInfo:this.personalInfo})
  })
}
}
