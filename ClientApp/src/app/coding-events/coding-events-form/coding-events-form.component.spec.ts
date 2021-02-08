import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CodingEventsFormComponent } from './coding-events-form.component';

describe('CodingEventsFormComponent', () => {
  let component: CodingEventsFormComponent;
  let fixture: ComponentFixture<CodingEventsFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CodingEventsFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CodingEventsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
