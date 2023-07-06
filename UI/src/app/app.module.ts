import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
<<<<<<< HEAD
import { LocationModule } from './location/location.module';
import { PersonalinfoModule } from './personalinfo/personalinfo.module';
=======
import { AddressesModule } from './addresses/addresses.module';
>>>>>>> e3ab7575143a93759349348abbe9024345220c2d
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
<<<<<<< HEAD
    LocationModule,
    PersonalinfoModule,
=======
    AddressesModule,
>>>>>>> e3ab7575143a93759349348abbe9024345220c2d
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
