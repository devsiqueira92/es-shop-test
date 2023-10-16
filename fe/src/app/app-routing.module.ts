import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import(
        /* webpackChunkName: "HomeModule" */
        './modules/pages/home/home.module'
      ).then((m) => m.HomeModule),
  },

  {
    path: 'shop-management',
    loadChildren: () =>
      import(
        /* webpackChunkName: "ShopModule" */
        './modules/pages/shop-management/shop-management.module'
      ).then((m) => m.ShopManagementModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
