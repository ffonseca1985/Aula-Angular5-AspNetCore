import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from './models/login';
import { OauthService } from '../shared/services/oauth/oauth.service';

import { Observable } from "rxjs/Observable";

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

    constructor(public router: Router, 
        public oauthService: OauthService) {}

    login: Login = new Login("", "");    

    ngOnInit() {}

    onLoggedin() {

        if (this.login.isValid())
        {
            this.oauthService.login(this.login.userName, 
                    this.login.password)
                    .subscribe(() => {
                        this.router.navigate(["/charts"]);
                    }, () => {

                        alert("Login incorreto!!");
                    });
        }
        else {
            alert("Favor preencher todos os campos!!");
        }
    }
}
