import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroContaComponent } from './cadastro-conta.component';

describe('CadastroContaComponent', () => {
  let component: CadastroContaComponent;
  let fixture: ComponentFixture<CadastroContaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastroContaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroContaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
