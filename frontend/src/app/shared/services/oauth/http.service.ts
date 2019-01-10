
import { Http, XHRBackend, RequestOptions, RequestOptionsArgs,
    Request, Response, Headers } from "@angular/http";
import { Injectable } from "@angular/core";
import { OauthService } from "./oauth.service";
import { Observable } from "rxjs/Observable";

@Injectable()
export class HttpService extends Http 
{
    constructor(backend : XHRBackend, options: RequestOptions, 
        private oauthService : OauthService ) {
        
            super(backend, options);
            
            let token = this.oauthService.getAccessToken();
            options.headers.set("Authorization", `Bearer ${token}`);
    }

    //Um request restorna um response
    request(url: string | Request, options?: RequestOptionsArgs):
         Observable<Response>
    {
        let token = this.oauthService.getAccessToken();

        if (typeof url == "string"){

            if(!options)
            {
                options = {headers: new Headers()};
            }

            options.headers.set("Authorization", `Bearer ${token}`);
            
        }else {
            url.headers.set("Authorization", `Bearer ${token}`);
        }

        return super.request(url, options)
            .catch(this.catchAuthError(this));
    }

    private catchAuthError(self : HttpService ){
        return (res: Response) => {

            if (res.status === 401 || res.status === 403){
                this.oauthService.logout();
            }

            return Observable.throw(res);
        };
    }
}