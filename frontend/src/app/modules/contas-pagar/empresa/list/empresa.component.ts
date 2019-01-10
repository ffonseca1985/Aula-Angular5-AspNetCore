import { Component, OnInit } from "@angular/core";
import { EmpresaService } from "../shared/services/empresa.service";
import { Empresa } from "../shared/models/empresa";

@Component({
    templateUrl: './empresa.component.html',
})
export class EmpresaComponent implements OnInit {

    empresas: Array<Empresa>;

    constructor(private empresaService: EmpresaService) {
        this.empresaService.get()
            .subscribe((response: Array<Empresa>) => {
                this.empresas = response;
            });
    }

    ngOnInit(): void {

    }
}