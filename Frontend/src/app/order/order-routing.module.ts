import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { OrderComponent } from './order.component';

const orderRoutes: Routes = [
  {
    path: "",
    component: OrderComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(orderRoutes)],
  exports: [RouterModule]
})

export class OrderRoutingModule {}
