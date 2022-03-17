import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReporteExtraComponent } from './reporte-extra.component';

describe('ReporteExtraComponent', () => {
  let component: ReporteExtraComponent;
  let fixture: ComponentFixture<ReporteExtraComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReporteExtraComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReporteExtraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
