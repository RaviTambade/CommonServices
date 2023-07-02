import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DebitCardComponent } from './debit-card/debit-card.component';
import { CreditCardComponent } from './credit-card/credit-card.component';
import { AccountComponent } from './account/account.component';



@NgModule({
  declarations: [
    DebitCardComponent,
    CreditCardComponent,
    AccountComponent
  ],
  imports: [
    CommonModule
  ]
})
export class PaymentGatewayModule { }
