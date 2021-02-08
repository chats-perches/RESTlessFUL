import { TestBed } from '@angular/core/testing';

import { CodingEventService } from './coding-event.service';

describe('CodingEventService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CodingEventService = TestBed.get(CodingEventService);
    expect(service).toBeTruthy();
  });
});
