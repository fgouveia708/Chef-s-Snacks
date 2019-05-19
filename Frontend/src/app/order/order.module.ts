import { NgModule } from '@angular/core';
import { OrderComponent } from './order.component';
import { OrderRoutingModule } from './order-routing.module';
@NgModule({
  declarations: [OrderComponent],
  imports: [
    OrderRoutingModule,
  ]
})
export class OrderModule { }

