import { ApiPostService } from './api-post-service';
import { TestBed } from '@angular/core/testing';

describe('ApiPostService', () => {
  let service: ApiPostService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApiPostService);
  });
  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
