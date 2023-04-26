import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RediretComponent } from './rediret.component';

describe('RediretComponent', () => {
  let component: RediretComponent;
  let fixture: ComponentFixture<RediretComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RediretComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RediretComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
