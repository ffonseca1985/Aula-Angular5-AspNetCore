
import { JwtHelper } from "angular2-jwt";
import { Injectable } from "@angular/core";
import { Http, Response, RequestOptions, Headers } from "@angular/http";
import { Router } from "@angular/router";

import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { UteisText } from "../../uteis/uteis.text";
import { environment } from "../../../../environments/environment";


@Injectable()
export class OauthService {

    constructor(private http: Http, private rota: Router) {

    }

    login(userName: string, password: string): Observable<any> {

        let client_id = "";
        let client_secret = "";

        //preparando a requisição
        //montando o content-type (atenção => estudar)
        let headers = new Headers({ "content-type": "application/x-www-form-urlencoded" });
        let options = new RequestOptions({ headers: headers });
        //montando o que vou enviar
        let body = `userName=${userName}&password=${password}&client_id=${client_id}&client_secret=${client_secret}&grant_type=password`;

        let url = `${environment.api}/token`;

        //enviando os dados
        return this.http.post(url, body, options)
            .map((response: any) => {

                let json = response.json();
                //quando retornar os dados 
                //vou colocar no localstorage
                localStorage.setItem("info_token", JSON.stringify(json));

            }).catch((err: Response) => {
                throw err;
            });
    }

    getAccessToken() {

        if (this.isAuthenticate()){
            let infoToken = localStorage.getItem("info_token");
            return JSON.parse(infoToken).access_token;
        }

        return null;
    }

    isAuthenticate(): boolean{

        //acesando o localstorage
        let infoToken = localStorage.getItem("info_token");

        if (infoToken == null || infoToken == undefined)
            return false;

        //lib externa    
        let jwtHelper : JwtHelper = new JwtHelper();
        let token = JSON.parse(infoToken).access_token;

        if (jwtHelper.isTokenExpired(token))
            return false;
        
        return true;
    }

    //Se tiver muitos dados para resgatar crie uma api de profile do usuario
    //Se é pouco dado, por exemplo: nome, sobrenome, perfil etc coloca-se no token
    //NOTA: token coloca-se os dados básicos
    getProfile() : any | null {

        if (this.isAuthenticate()){

            let infoToken = localStorage.getItem("info_token");
            let token = JSON.parse(infoToken).access_token;

            let jwtHelper : JwtHelper = new JwtHelper();
            var userProfile = jwtHelper.decodeToken(token); //toda a info do usuario contida no token
            
            return userProfile;
        }

        return null;
    }

    logout()
    {
        if (this.isAuthenticate()) {
            localStorage.removeItem("info_token");
        }
        
        //redirect para a tela de login
        this.rota.navigate(["login"]);
    }

}