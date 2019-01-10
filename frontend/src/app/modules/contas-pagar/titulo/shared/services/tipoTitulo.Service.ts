import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { TipoPgto } from "../models/tipoPgto";

import { Http, Request, RequestOptions, Response } from '@angular/http';
import { UteisText } from '../../../../../shared/uteis/uteis.text';

import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { HttpService } from "../../../../../shared/services/oauth/http.service";
import { environment } from '../../../../../../environments/environment';
import { TenantService } from "../../../../../shared/services/service.tenant";
import { TipoTitulo } from "../models/tipoTitulo";


@Injectable()
export class TipoTituloService {

    private api : string;

    constructor(private http: HttpService, private tenantService: TenantService) {
        
        this.api = UteisText.concatenateUrl(environment.api, 
            tenantService.get().id, 
            "contasAPagar", "tipotitulo");
    }

    get() : Observable<Array<TipoTitulo> | null> {

        return this.http.get(this.api)
            .map((response: Response) => {

                var dados = response.json();
                var tipoTitulos: Array<TipoTitulo> = new Array<TipoTitulo>();

                for (let index = 0; index < dados.length; index++) {
                    let result = dados[index];

                    let tipoTitulo = new TipoTitulo(result.descricao);
                    tipoTitulo.id = result.id;   

                    tipoTitulos.push(tipoTitulo);
                }

                return tipoTitulos;
            });
    }
}