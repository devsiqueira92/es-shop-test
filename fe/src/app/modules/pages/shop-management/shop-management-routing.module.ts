import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListShirtComponent } from './components/list-shirt/list-shirt.component';
import { EditShirtComponent } from './components/edit-shirt/edit-shirt.component';

const routes: Routes = [
  {
    path: ``,
    component: ListShirtComponent,
  },
  {
    path: `:id`,
    component: EditShirtComponent,
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ShopManagementRoutingModule {}
