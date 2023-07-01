import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AllpersonalinfoComponent } from './allpersonalinfo/allpersonalinfo.component';
import { GetpersonalinfoComponent } from './getpersonalinfo/getpersonalinfo.component';
import { EditpersonalinfoComponent } from './editpersonalinfo/editpersonalinfo.component';
import { RemovepersonalinfoComponent } from './removepersonalinfo/removepersonalinfo.component';
import { AddpersonalinfoComponent } from './addpersonalinfo/addpersonalinfo.component';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';


@NgModule({
  declarations: [
    AllpersonalinfoComponent,
    GetpersonalinfoComponent,
    EditpersonalinfoComponent,
    RemovepersonalinfoComponent,
    AddpersonalinfoComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule
  ],
  exports:[
    AddpersonalinfoComponent
  ]
})
export class PersonalinfoModule { }
