import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CodingEventsComponent } from './coding-events.component';

describe('CodingEventsComponent', () => {
  let component: CodingEventsComponent;
  let fixture: ComponentFixture<CodingEventsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CodingEventsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CodingEventsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
