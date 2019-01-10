import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContasPagarRoutingModule } from './contas-pagar-routing.module';
import { EmpresaComponent } from './empresa/list/empresa.component';
import { FornecedorComponent } from './fornecedor/list/fornecedor.component';
import { EmpresaService } from './empresa/shared/services/empresa.service';
import { FornecedorService } from './fornecedor/shared/services/fornecedor.service';
import { TipoPgtoService } from './titulo/shared/services/tipoPgto.Service';
import { TipoTituloService } from './titulo/shared/services/tipoTitulo.Service';
import { TituloService } from './titulo/shared/services/titulo.Service';
import { TituloCreateComponent } from './titulo/create/titulo.create.component';
import { PageHeaderModule } from '../../shared/modules/page-header/page-header.module';
import { FormsModule } from '@angular/forms';
import { HttpService } from '../../shared/services/oauth/http.service';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ContasPagarRoutingModule,
    PageHeaderModule,

  ],
  providers: [
    EmpresaService,
    FornecedorService,
    TipoPgtoService,
    TipoTituloService,
    TituloService,
    HttpService
  ],
  declarations: [
    EmpresaComponent,
    FornecedorComponent,
    TituloCreateComponent
  ]
})
export class ContasPagarModule { }
