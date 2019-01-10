import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RemoverUsuarioComponent } from './remove/remover-usuario/remover-usuario.component';
import { EditarUsuarioComponent } from './edite/editar-usuario/editar-usuario.component';
import { CadastroUsuarioComponent } from './create/cadastro-usuario/cadastro-usuario.component';
import { ListarUsuarioComponent } from './list/listar-usuario/listar-usuario.component';
import { ControleUsuarioRoutingModule } from './controle-usuario-routing.module';
import { PageHeaderModule } from '../../shared/modules/page-header/page-header.module';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { UsuarioService } from './shared/services/usuarioService';
import { HttpService } from '../../shared/services/oauth/http.service';
import { ProfileComponent } from './profile/profile.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ControleUsuarioRoutingModule,
    PageHeaderModule,
  ],
  declarations: 
  [
    RemoverUsuarioComponent, 
    EditarUsuarioComponent, 
    CadastroUsuarioComponent, 
    ListarUsuarioComponent,
    ProfileComponent
  ],
   providers: [UsuarioService, HttpService]
})
export class ControleUsuarioModule { }
