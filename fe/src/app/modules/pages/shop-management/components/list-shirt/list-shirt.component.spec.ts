import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListShirtComponent } from './list-shirt.component';

describe('ListShirtComponent', () => {
  let component: ListShirtComponent;
  let fixture: ComponentFixture<ListShirtComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListShirtComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListShirtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
