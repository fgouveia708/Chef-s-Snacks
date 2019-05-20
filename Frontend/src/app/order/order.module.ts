import { NgModule } from '@angular/core';
import { OrderComponent } from './order.component';
import { OrderRoutingModule } from './order-routing.module';
import { CommonModule } from '@angular/common';
import { ToastrModule } from 'ngx-toastr';
import { HttpClientModule } from '@angular/common/http';
@NgModule({
  declarations: [OrderComponent],
  imports: [
    CommonModule,
    OrderRoutingModule,
    HttpClientModule 
  ],
})
export class OrderModule { }

