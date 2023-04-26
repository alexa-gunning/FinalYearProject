import { TestBed } from '@angular/core/testing';

import { DeliverycompanyService } from './deliverycompany.service';

describe('DeliverycompanyService', () => {
  let service: DeliverycompanyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DeliverycompanyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
