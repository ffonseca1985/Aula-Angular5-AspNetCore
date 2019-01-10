import { Injectable } from "@angular/core";
import { environment } from '../../../../../environments/environment';

import { Http, Request, RequestOptions, Response, Headers } from '@angular/http';



//bibliotecas usadas para tratados do request/ response
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { OauthService } from "../../../../shared/services/oauth/oauth.service";
import { HttpService } from "../../../../shared/services/oauth/http.service";
import { UteisText } from "../../../../shared/uteis/uteis.text";

@Injectable()
export class UsuarioService {

    tenantId : any;

    constructor(private oauthService :  OauthService,
        private httpService : HttpService) {

        let profile = this.oauthService.getProfile();
        console.log(profile)

        this.tenantId = profile.TenantId;
    }

    create(usuario: any) : Observable<any | null> {
        
        var url = UteisText.concatenateUrl(environment.api, "ControleDeAcesso", this.tenantId);
        
        let headers = new Headers({ "content-type": "application/x-www-form-urlencoded" });
        let options = new RequestOptions({ headers: headers });
        
        return this.httpService.post(url, usuario)
            .catch( (error : any) => 
        {
            throw error;
        })    
    }
}