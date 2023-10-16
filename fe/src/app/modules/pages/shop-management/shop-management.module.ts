import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ShopManagementRoutingModule } from './shop-management-routing.module';
import { EditShirtComponent } from './components/edit-shirt/edit-shirt.component';
import { ListShirtComponent } from './components/list-shirt/list-shirt.component';

import { NzTableModule } from 'ng-zorro-antd/table';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [EditShirtComponent, ListShirtComponent],
  imports: [
    CommonModule,
    ShopManagementRoutingModule,
    NzTableModule,
    FormsModule,
  ],
})
export class ShopManagementModule {}
