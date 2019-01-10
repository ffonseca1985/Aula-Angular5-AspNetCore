
import { NgModule } from "@angular/core";
import { HomeRoutingModule } from "./home-routing.module";
import { CommonModule } from "@angular/common";
import { HomeComponent } from "./home.component";
import { HeaderComponent } from './header/header.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { TranslateModule } from "@ngx-translate/core";
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from "@angular/forms";

@NgModule({
    imports: [
        FormsModule,
        CommonModule,
        HomeRoutingModule,
        TranslateModule,
        NgbDropdownModule.forRoot()],
    declarations: [HomeComponent, HeaderComponent, SidebarComponent]    
})
export class HomeModule {}