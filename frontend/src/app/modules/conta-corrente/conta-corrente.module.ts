import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CadastroContaComponent } from './create/cadastro-conta/cadastro-conta.component';
import { EditarContaComponent } from './edite/editar-conta/editar-conta.component';
import { RemoverContaComponent } from './remove/remover-conta/remover-conta.component';
import { ListarContaComponent } from './list/listar-conta/listar-conta.component';
@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
    CadastroContaComponent, 
    EditarContaComponent, 
    RemoverContaComponent, 
    ListarContaComponent]
})
export class ContaCorrenteModule { }
