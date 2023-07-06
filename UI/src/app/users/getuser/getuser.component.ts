import { Component } from '@angular/core';

@Component({
  selector: 'app-getuser',
  templateUrl: './getuser.component.html',
  styleUrls: ['./getuser.component.css']
})
export class GetuserComponent {
  user:User;
  @Input() userId:number;
  @Output() sendUser=new EventEmitter();
  constructor(private svc :UserService){
    this.user={
      id: 0,
      aadharId: '',
      firstName: '',
      lastName: '',
      birthDate: '',
      gender: '',
      email: '',
      contactNumber: ''
    },
    this.userId=1;
  }
    ngOnInit(): void {
      this.svc.getUser(this.userId).subscribe((response)=>{
        this.user=response
        console.log(response)
        this.sendUser.emit({user:this.user})
      })
  }
  getUser(id:any){
    this.svc.getUser(id).subscribe((response)=>{
      this.user=response
      console.log(response)
      this.sendUser.emit({user:this.user})
    })
  }
}
