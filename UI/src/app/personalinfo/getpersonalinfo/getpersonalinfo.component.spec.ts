import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetpersonalinfoComponent } from './getpersonalinfo.component';

describe('GetpersonalinfoComponent', () => {
  let component: GetpersonalinfoComponent;
  let fixture: ComponentFixture<GetpersonalinfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetpersonalinfoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetpersonalinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
