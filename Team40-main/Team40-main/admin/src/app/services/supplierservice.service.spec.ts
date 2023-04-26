import { TestBed } from '@angular/core/testing';

import { SupplierService } from './supplierservice.service';

describe('SupplierserviceService', () => {
  let service: SupplierService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SupplierService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
