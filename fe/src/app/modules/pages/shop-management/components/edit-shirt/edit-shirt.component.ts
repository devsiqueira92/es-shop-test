import { Component, OnInit } from '@angular/core';
import { ColorService } from '../../../../shared/services/color.service';
import { FabricService } from '../../../../shared/services/fabric.service';
import { ShirtService } from '../../services/shirt.service';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';

@Component({
  templateUrl: './edit-shirt.component.html',
  styleUrls: ['./edit-shirt.component.scss'],
})
export class EditShirtComponent implements OnInit {
  data: any = [];

  colors: any = [];

  fabrics: any = [];

  addImage(colorId: number, fabricId: number) {
    const item = this.data.filter(
      (item: any) => item.colorId === colorId && item.fabricId === fabricId
    );

    console.log(item);
  }

  constructor(
    private colorService: ColorService,
    private shirtService: ShirtService,
    private fabricService: FabricService,
    private route: ActivatedRoute
  ) {
    this.colorService.getColors().subscribe((data) => (this.colors = data));
    this.fabricService.getFabrics().subscribe((data) => (this.fabrics = data));
    this.shirtService
      .getShirtsSpecification(this.route.snapshot.params[`id`])
      .subscribe((data) => (this.data = data));
  }

  ngOnInit(): void {}

  getItemsByColorAndFabric(colorId: number, fabricId: number): any[] {
    return this.data.filter(
      (item: any) => item.colorId === colorId && item.fabricId === fabricId
    );
  }
}
