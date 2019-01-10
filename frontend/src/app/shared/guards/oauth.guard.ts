
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from "@angular/router";

import { Observable } from "rxjs/Observable";
import { OauthService } from "../services/oauth/oauth.service";
import { Injectable } from "@angular/core";

@Injectable()
export class OauthGuard implements CanActivate {

    constructor(private rota : Router, 
                private oauthService: OauthService) {
    }
    
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean 
            | Observable<boolean> | Promise<boolean> {

        if (!this.oauthService.isAuthenticate()){
            this.oauthService.logout();
            return false;
        }
        return true;
    }
}