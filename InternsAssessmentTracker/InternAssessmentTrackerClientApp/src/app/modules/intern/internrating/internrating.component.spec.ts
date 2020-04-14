import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InternratingComponent } from './internrating.component';

describe('InternratingComponent', () => {
  let component: InternratingComponent;
  let fixture: ComponentFixture<InternratingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InternratingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InternratingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
