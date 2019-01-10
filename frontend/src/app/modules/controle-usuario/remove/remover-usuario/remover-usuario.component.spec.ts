import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoverUsuarioComponent } from './remover-usuario.component';

describe('RemoverUsuarioComponent', () => {
  let component: RemoverUsuarioComponent;
  let fixture: ComponentFixture<RemoverUsuarioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RemoverUsuarioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RemoverUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
