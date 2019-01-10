import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmpresaComponent } from './empresa/list/empresa.component';
import { FornecedorComponent } from './fornecedor/list/fornecedor.component';
import { TituloCreateComponent } from './titulo/create/titulo.create.component';

const routes: Routes = [
    { path: 'create', component: TituloCreateComponent },
    { path: 'empresa', component: EmpresaComponent},
    { path: 'fornecedor', component: FornecedorComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContasPagarRoutingModule { }
