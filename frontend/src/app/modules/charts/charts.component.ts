
import { Component } from "@angular/core";
import { UsuarioService } from "./shared/services/usuario.service";
import { ChartUsuario } from "./shared/models/chart.usuario";
import { Observable } from 'rxjs/Observable';

@Component({
    templateUrl: './charts.component.html', //não precisa ser o mesmo nome
    selector: 'app-charts'
})
export class ChartsComponent {

    usuarios : Array<ChartUsuario>;

    constructor(private usuarioService: UsuarioService) 
    {
        var observable = this.usuarioService.get();
        
        observable.subscribe((usuarios : Array<ChartUsuario>) => {
                this.usuarios = usuarios;
        });
    }
}