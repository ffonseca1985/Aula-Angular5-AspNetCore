
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";

import { Http, Request, RequestOptions, Headers, Response } from '@angular/http';
import { UteisText } from '../../../../../shared/uteis/uteis.text';

import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { HttpService } from "../../../../../shared/services/oauth/http.service";
import { environment } from '../../../../../../environments/environment';
import { TenantService } from "../../../../../shared/services/service.tenant";
import { Titulo } from "../models/Titulo";
import { OauthService } from "../../../../../shared/services/oauth/oauth.service";



@Injectable()
export class TituloService {

    profile : any;

    constructor(private httpService : HttpService, private oauthService : OauthService) {
        this.profile = this.oauthService.getProfile();
    }

    create (titulo :  Titulo) : Observable<Titulo | any>{

        var url = UteisText.concatenateUrl(environment.api, this.profile.tenantId,
             "contasapagar", "titulo");
        
        let headers = new Headers({ "content-type": "application/x-www-form-urlencoded" });
        let options = new RequestOptions({ headers: headers });

        return this.httpService.post(url, titulo, options)
            .map((response : Response) => {
                
                var result = response.json();

                var model : Titulo = new Titulo(result.tipoTitulo, result.tipoPgto);
                model.id = result.id;

                return model;    
            });
    }
}