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
id:number;
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
  },
  this.id=1;
}
  ngOnInit(): void {
  }
  updatePersonalInfo(){
    this.svc.updatePersonalInfo(this.id,this.personalInfo).subscribe((response)=>{
      console.log(response)
     })
  }
}
