import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderComponent } from './order.component';
import { OrderRoutingModule } from './order-routing.module';
import { MatButtonModule, MatCheckboxModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
@NgModule({
  declarations: [OrderComponent],
  imports: [

    CommonModule,
    OrderRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCheckboxModule,
  ]
})
export class OrderModule { }

