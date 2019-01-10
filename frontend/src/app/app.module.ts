import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { TenantService } from './shared/services/service.tenant';
import { FormsModule } from '@angular/forms';
import { OauthService } from './shared/services/oauth/oauth.service';
import { OauthGuard } from './shared/guards/oauth.guard';

export function createTranslateLoader(http: HttpClient) {
  // for development
  // return new TranslateHttpLoader(http, '/start-angular/SB-Admin-BS4-Angular-5/master/dist/assets/i18n/', '.json');
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

@NgModule({
  declarations: [ //tudo que é componente
    AppComponent
  ],
  imports: [ //tudo que modulo interno e externo
    CommonModule,
    BrowserModule,
    HttpModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    TranslateModule.forRoot({
      loader: {
          provide: TranslateLoader,
          useFactory: createTranslateLoader,
          deps: [HttpClient]
      }
  }),
  ],
  providers: [TenantService, OauthService, OauthGuard], //filtro, sevices, etc
  bootstrap: [AppComponent]
})
export class AppModule { }
