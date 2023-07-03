import { Component } from '@angular/core';
import { Personalinfo } from '../personalinfo';
import { PersonalinfoService } from '../personalinfo.service';

@Component({
  selector: 'app-removepersonalinfo',
  templateUrl: './removepersonalinfo.component.html',
  styleUrls: ['./removepersonalinfo.component.css']
})
export class RemovepersonalinfoComponent {
  personalInfo:Personalinfo ;
  personalInfoId:number |any;
  constructor(private svc:PersonalinfoService){
    this.personalInfo={
      id: 0,
      aadharId: '',
      firstName: '',
      lastName: '',
      birthDate: '',
      gender: '',
      email: '',
      contactNumber: ''
    }
    this.personalInfoId=2;
  }
    ngOnInit(): void {
    }
    removePersonalInfo(){
      this.svc.removePersonalInfo(this.personalInfoId).subscribe((response)=>{
        console.log(response)
       })
    }
    receivePersonalInfo($event:any){
    this.personalInfo=$event.personalInfo
    }
}
