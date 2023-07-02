import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UpdateAccountComponent } from './update-account/update-account.component';
import { CreateAccountComponent } from './create-account/create-account.component';
import { DetailsComponent } from './details/details.component';



@NgModule({
  declarations: [
    UpdateAccountComponent,
    CreateAccountComponent,
    DetailsComponent
  ],
  imports: [
    CommonModule
  ]
})
export class AccountManagerModule { }
