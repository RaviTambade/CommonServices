import { Component, OnInit } from '@angular/core';
import { Personalinfo } from '../personalinfo';
import { PersonalinfoService } from '../personalinfo.service';

@Component({
  selector: 'app-addpersonalinfo',
  templateUrl: './addpersonalinfo.component.html',
  styleUrls: ['./addpersonalinfo.component.css']
})
export class AddpersonalinfoComponent implements OnInit {
  personalInfo: Personalinfo;
  constructor(private svc: PersonalinfoService) {
    this.personalInfo = {
      id: 0,
      aadharId: '',
      firstName: '',
      lastName: '',
      birthDate: '',
      gender: '',
      email: '',
      contactNumber: ''
    }
  }

  ngOnInit(): void {
  }
  addPerson() {
    this.svc.addPersonalInfo(this.personalInfo).subscribe((response) => {
   console.log(response)
    })
  }
}
