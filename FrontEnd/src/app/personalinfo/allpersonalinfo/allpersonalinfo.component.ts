import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { Personalinfo } from '../personalinfo';
import { PersonalinfoService } from '../personalinfo.service';

@Component({
  selector: 'app-allpersonalinfo',
  templateUrl: './allpersonalinfo.component.html',
  styleUrls: ['./allpersonalinfo.component.css']
})
export class AllpersonalinfoComponent implements OnInit{
allPersonalInfo:Personalinfo[];
private subscription: Subscription;
constructor(private svc:PersonalinfoService){
  this.allPersonalInfo=[];
  this.subscription = new Subscription();
}
  ngOnInit(): void {
  this.subscription= this.svc.getallPersonalInfo().subscribe((response)=>{
    this.allPersonalInfo=response
   })
  }
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }
}
