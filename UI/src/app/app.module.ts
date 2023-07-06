import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { AddressesModule } from './addresses/addresses.module';
import { RouterModule, Routes } from '@angular/router';
import { AuthenticationModule, authRoutes } from './authentication/authentication.module';
import { AuthenticationRoutingComponent } from './authentication/authentication-routing/authentication-routing.component';
import { AccountManagerModule } from './account-manager/account-manager.module';
import { PaymentGatewayModule } from './payment-gateway/payment-gateway.module';
import { UsersModule } from './users/users.module';

const routes: Routes = [
{path:'authentication',component:AuthenticationRoutingComponent,children:authRoutes },
]
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AddressesModule,
    AuthenticationModule,
    AccountManagerModule,
    RouterModule.forRoot(routes),
    PaymentGatewayModule,
    UsersModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
