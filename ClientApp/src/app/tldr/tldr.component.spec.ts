import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TldrComponent } from './tldr.component';

describe('TldrComponent', () => {
  let component: TldrComponent;
  let fixture: ComponentFixture<TldrComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TldrComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TldrComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
