import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ShirtService } from '../../services/shirt.service';

@Component({
  selector: 'app-list-shirt',
  templateUrl: './list-shirt.component.html',
  styleUrls: ['./list-shirt.component.scss'],
})
export class ListShirtComponent implements OnInit {
  data: any = [
    {
      id: 1,
      itemName: `Skeleton t-shirt`,
      numberColor: 5,
      numberFabric: 8,
      numberImages: 10,
    },
    {
      id: 2,
      itemName: ``,
      numberColor: 3,
      numberFabric: 5,
      numberImages: 9,
    },
    {
      id: 3,
      itemName: ``,
      numberColor: 4,
      numberFabric: 2,
      numberImages: 3,
    },
  ];
  constructor(private router: Router, private shirtService: ShirtService) {}

  ngOnInit(): void {
    this.shirtService.getShirts().subscribe((data) => (this.data = data));
  }

  edit(id: number) {
    this.router.navigate([`shop-management`, id]);
  }
}
