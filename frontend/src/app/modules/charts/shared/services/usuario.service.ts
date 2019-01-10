import { Injectable } from '@angular/core';
import { ChartUsuario } from '../models/chart.usuario';
import { environment } from '../../../../../environments/environment';

import { Http, Request, RequestOptions, Response } from '@angular/http';

//bibliotecas usadas para tratados do request/ response
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { TenantService } from '../../../../shared/services/service.tenant';
import { UteisText } from '../../../../shared/uteis/uteis.text';

@Injectable()
export class UsuarioService {

  private api: string;

  constructor(private http : Http, private tenantService: TenantService) 
  { 
      this.api = UteisText.concatenateUrl(environment.api,"ControleDeAcesso", tenantService.get().id);
  }

  get(): Observable<Array<ChartUsuario> | {}>  {

    console.log(this.api);
    var observable = this.http.get(this.api).map((response: Response) => {

          let json = response.json();
          var usuarios: Array<ChartUsuario> = new Array<ChartUsuario>();

          for (var index = 0; index < json.length; index++) {
            var element = json[index];
            var usuario = new ChartUsuario(element.nome, element.sobrenome, element.idade);
            usuarios.push(usuario);
          } 

          return usuarios;

        }).catch((erro: any) => {
          throw erro;
        });

    return observable;
  }
}
