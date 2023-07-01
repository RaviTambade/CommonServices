import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllpersonalinfoComponent } from './allpersonalinfo.component';

describe('AllpersonalinfoComponent', () => {
  let component: AllpersonalinfoComponent;
  let fixture: ComponentFixture<AllpersonalinfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllpersonalinfoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AllpersonalinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
