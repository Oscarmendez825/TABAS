import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrearMaletasComponent } from './crear-maletas.component';

describe('CrearMaletasComponent', () => {
  let component: CrearMaletasComponent;
  let fixture: ComponentFixture<CrearMaletasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CrearMaletasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CrearMaletasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
