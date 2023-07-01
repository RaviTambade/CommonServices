import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemovepersonalinfoComponent } from './removepersonalinfo.component';

describe('RemovepersonalinfoComponent', () => {
  let component: RemovepersonalinfoComponent;
  let fixture: ComponentFixture<RemovepersonalinfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RemovepersonalinfoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RemovepersonalinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
