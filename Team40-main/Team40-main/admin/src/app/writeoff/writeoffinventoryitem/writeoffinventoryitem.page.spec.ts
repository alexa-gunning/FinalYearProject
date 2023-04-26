import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { WriteoffinventoryitemPage } from './writeoffinventoryitem.page';

describe('WriteoffinventoryitemPage', () => {
  let component: WriteoffinventoryitemPage;
  let fixture: ComponentFixture<WriteoffinventoryitemPage>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ WriteoffinventoryitemPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(WriteoffinventoryitemPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
