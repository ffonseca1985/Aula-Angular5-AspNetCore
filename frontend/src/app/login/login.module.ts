import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { PageHeaderModule } from '../shared/modules/page-header/page-header.module';

@NgModule({
    imports: [CommonModule,
        FormsModule,
        LoginRoutingModule,
        PageHeaderModule],
    declarations: [LoginComponent]
})
export class LoginModule {}
