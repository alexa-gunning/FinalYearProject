import { TestBed } from '@angular/core/testing';

import { ClientordersService } from './clientorders.service';

describe('ClientordersService', () => {
  let service: ClientordersService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ClientordersService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
