import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditShirtComponent } from './edit-shirt.component';

describe('EditShirtComponent', () => {
  let component: EditShirtComponent;
  let fixture: ComponentFixture<EditShirtComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditShirtComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditShirtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
