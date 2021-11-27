import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RequestTableListComponent } from './request-table-list.component';

describe('RequestTableListComponent', () => {
  let component: RequestTableListComponent;
  let fixture: ComponentFixture<RequestTableListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RequestTableListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RequestTableListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
