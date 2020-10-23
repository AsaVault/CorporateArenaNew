import { TestBed } from '@angular/core/testing';

import { BrainTeaserService } from './brain-teaser.service';

describe('BrainTeaserService', () => {
  let service: BrainTeaserService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BrainTeaserService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
