import { TestBed } from '@angular/core/testing';

import { TrafficUpdateService } from './traffic-update.service';

describe('TrafficUpdateService', () => {
  let service: TrafficUpdateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TrafficUpdateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
