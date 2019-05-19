import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: '../order/order.module#OrderModule'
    // redirectTo: 'users',
    // pathMatch: 'full'
  },
  {
    path: 'produtos',
    loadChildren: '../order/order.module#OrderModule'
  },
  {
    path: 'usuarios',
    loadChildren: '../order/order.module#OrderModule'
  },
  {
    path: 'pedidos',
    loadChildren: '../order/order.module#OrderModule'
  },

  {
    path: 'categorias',
    loadChildren: '../order/order.module#OrderModule'
  },

  {
    path: 'login',
    loadChildren: '../order/order.module#OrderModule'
  },
  {
    path: 'compradores',
    loadChildren: '../order/order.module#OrderModule'
  },
  {
    path: 'condominios',
    loadChildren: '../order/order.module#OrderModule'
  }
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class CoreRoutingModule {}
