import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BrainTeaserComponent } from './brain-teaser.component';

describe('BrainTeaserComponent', () => {
  let component: BrainTeaserComponent;
  let fixture: ComponentFixture<BrainTeaserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BrainTeaserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BrainTeaserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
