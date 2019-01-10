import { Injectable } from "@angular/core";
import { Tenant } from "../tenant/tenant";
import { OauthService } from "./oauth/oauth.service";

@Injectable()
export class TenantService {

/**
 *
 */
constructor(private oauthService: OauthService) {
}

    //Vamos usar o localstorage para resgatar os dados básicos do tenant
    get() : Tenant {
        
        var profile = this.oauthService.getProfile();

        //por enquanto/ só por teste
        var tenant: Tenant = new Tenant();
        tenant.id = profile.IdTenant;
        tenant.nome = "Tenant Test";

        return tenant;
    }
}