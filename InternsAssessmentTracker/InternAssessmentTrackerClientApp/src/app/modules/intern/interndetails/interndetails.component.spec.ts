import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InterndetailsComponent } from './interndetails.component';

describe('InterndetailsComponent', () => {
  let component: InterndetailsComponent;
  let fixture: ComponentFixture<InterndetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InterndetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InterndetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
