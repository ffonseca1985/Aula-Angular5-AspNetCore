import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../shared/services/usuarioService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastro-usuario',
  templateUrl: './cadastro-usuario.component.html',
  styleUrls: ['./cadastro-usuario.component.scss']
})
export class CadastroUsuarioComponent implements OnInit {

  usuario : any = {};

  constructor(private usuarioService : UsuarioService,
    private router : Router) {

  }

  salvar(){

      this.usuarioService.create(this.usuario)
        .subscribe(x => {
          this.router.navigate(["charts"]);
        }); 
  }

  ngOnInit() {
  }

}
