import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BagCartComponent } from './bag-cart.component';

describe('BagCartComponent', () => {
  let component: BagCartComponent;
  let fixture: ComponentFixture<BagCartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BagCartComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BagCartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
