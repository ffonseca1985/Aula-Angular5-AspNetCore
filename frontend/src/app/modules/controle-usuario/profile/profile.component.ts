import { Component } from "@angular/core";
import { OauthService } from "../../../shared/services/oauth/oauth.service";

@Component({
    styleUrls: [],
    templateUrl: "./profile.component.html"
})
export class ProfileComponent {

    profile: any;

    constructor(private oauthService: OauthService) 
    {
        this.profile = this.oauthService.getProfile();
    }
}