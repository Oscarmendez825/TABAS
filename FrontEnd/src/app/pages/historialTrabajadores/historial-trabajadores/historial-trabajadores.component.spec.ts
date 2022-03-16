import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HistorialTrabajadoresComponent } from './historial-trabajadores.component';

describe('HistorialTrabajadoresComponent', () => {
  let component: HistorialTrabajadoresComponent;
  let fixture: ComponentFixture<HistorialTrabajadoresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HistorialTrabajadoresComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HistorialTrabajadoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
