import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoverContaComponent } from './remover-conta.component';

describe('RemoverContaComponent', () => {
  let component: RemoverContaComponent;
  let fixture: ComponentFixture<RemoverContaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RemoverContaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RemoverContaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
