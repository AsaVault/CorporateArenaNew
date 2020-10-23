import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TrafficUpdateComponent } from './traffic-update.component';

describe('TrafficUpdateComponent', () => {
  let component: TrafficUpdateComponent;
  let fixture: ComponentFixture<TrafficUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrafficUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrafficUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
