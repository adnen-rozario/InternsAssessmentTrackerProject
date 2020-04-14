import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InternProjectComponent } from './internProject.component';

describe('ProjectsComponent', () => {
  let component: InternProjectComponent;
  let fixture: ComponentFixture<InternProjectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InternProjectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InternProjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
