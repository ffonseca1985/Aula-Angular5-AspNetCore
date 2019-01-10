import { Injectable } from '@angular/core';
import { Http, Request, RequestOptions, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { UteisText } from '../../../../../shared/uteis/uteis.text';
import { TenantService } from '../../../../../shared/services/service.tenant';
import { environment } from '../../../../../../environments/environment';
import { Fornecedor } from '../models/fornecedor';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

@Injectable()
export class FornecedorService {

    private api: string;

    constructor(private http: Http, private tenantService: TenantService) {
        
        this.api = UteisText.concatenateUrl(environment.api, 
            tenantService.get().id, 
            "contasAPagar/fornecedor");
    }

    get(): Observable<Array<Fornecedor> | {}> {

        console.log(this.api);
        var observable = this.http.get(this.api).map((response: Response) => {

            let json = response.json();
            console.log(json);
            var fornecedores: Array<Fornecedor> = new Array<Fornecedor>();

            for (var index = 0; index < json.length; index++) {
                var element = json[index];
                var fornecedor = new Fornecedor(element.id, element.razaoSocial);
                fornecedores.push(fornecedor);
            }

            return fornecedores;

        }).catch((erro: any) => {
            throw erro;
        });

        return observable;
    }
}
