
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ChartsRoutingModule } from "./charts-routing.modules";
import { ChartsComponent } from "./charts.component";
import { UsuarioService } from "./shared/services/usuario.service";
import { HttpModule } from "@angular/http";

@NgModule({
    imports :[CommonModule, ChartsRoutingModule], //modulos
    declarations:[ChartsComponent], //componentes
    providers: [UsuarioService]
})
export class ChartsModule {

}