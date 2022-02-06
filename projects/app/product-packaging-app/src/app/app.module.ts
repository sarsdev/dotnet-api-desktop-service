import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductMasterDetailComponent } from './product-master-detail/product-master-detail.component';
import { PoModule } from '@po-ui/ng-components';
import { ProductMasterComponent } from './product-master/product-master.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductMasterDetailComponent,
    ProductMasterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    PoModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
