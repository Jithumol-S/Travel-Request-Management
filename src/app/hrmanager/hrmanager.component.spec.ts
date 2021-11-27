import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HRManagerComponent } from './hrmanager.component';

describe('HRManagerComponent', () => {
  let component: HRManagerComponent;
  let fixture: ComponentFixture<HRManagerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HRManagerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HRManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
