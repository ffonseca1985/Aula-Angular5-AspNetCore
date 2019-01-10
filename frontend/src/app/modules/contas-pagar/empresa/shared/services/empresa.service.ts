import { Injectable } from '@angular/core';

import { Http, Request, RequestOptions, Response } from '@angular/http';

//bibliotecas usadas para tratados do request/ response
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { UteisText } from '../../../../../shared/uteis/uteis.text';
import { TenantService } from '../../../../../shared/services/service.tenant';
import { environment } from '../../../../../../environments/environment';
import { Empresa } from '../models/empresa';

@Injectable()
export class EmpresaService {

    private api: string;

    constructor(private http: Http, private tenantService: TenantService) {
        
        this.api = UteisText.concatenateUrl(environment.api, 
            tenantService.get().id, 
            "contasAPagar/empresa");
    }

    get(): Observable<Array<Empresa> | {}> {

        console.log(this.api);
        var observable = this.http.get(this.api).map((response: Response) => {

            let json = response.json();
            console.log(json);
            var empresas: Array<Empresa> = new Array<Empresa>();

            for (var index = 0; index < json.length; index++) {
                var element = json[index];
                var empresa = new Empresa(element.id, element.razaoSocial);
                empresas.push(empresa);
            }
            return empresas;

        }).catch((erro: any) => {
            throw erro;
        });

        return observable;
    }
}
