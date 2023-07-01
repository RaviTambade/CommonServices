import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { AddressesModule } from './addresses/addresses.module';
import { PersonalinfoModule } from './personalinfo/personalinfo.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AddressesModule,
    PersonalinfoModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
