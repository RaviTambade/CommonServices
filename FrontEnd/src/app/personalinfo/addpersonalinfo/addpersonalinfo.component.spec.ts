import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddpersonalinfoComponent } from './addpersonalinfo.component';

describe('AddpersonalinfoComponent', () => {
  let component: AddpersonalinfoComponent;
  let fixture: ComponentFixture<AddpersonalinfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddpersonalinfoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddpersonalinfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
