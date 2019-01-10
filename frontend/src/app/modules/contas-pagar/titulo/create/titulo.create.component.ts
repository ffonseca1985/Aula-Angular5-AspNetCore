import { Component } from "@angular/core";
import { Titulo } from "../shared/models/Titulo";
import { TituloService } from "../shared/services/titulo.Service";
import { TipoTitulo } from "../shared/models/tipoTitulo";
import { TipoTituloService } from "../shared/services/tipoTitulo.Service";
import { TipoPgtoService } from "../shared/services/tipoPgto.Service";
import { TipoPgto } from "../shared/models/tipoPgto";

@Component({
    templateUrl: "./titulo.create.component.html"
})
export class TituloCreateComponent {

    titulo = {};
    tipoTitulos: Array<TipoTitulo>;
    tipoPgtos: Array<TipoPgto>;

    constructor(
        private tituloService: TituloService,
        private tipoTituloService: TipoTituloService,
        private tipoPgtoService: TipoPgtoService) {

            this.loadTipoPgto();
            this.loadTipoTitulo();
    }

    private loadTipoTitulo() {
        this.tipoTituloService.get()
            .subscribe((response: Array<TipoTitulo>) => {
                this.tipoTitulos = response;
            });
    }

    private loadTipoPgto(){
        this.tipoPgtoService.get()
            .subscribe((response: Array<TipoPgto>) => {
                this.tipoPgtos = response;
            });
    }

    create() {
        alert("salvo!!");
    }
}