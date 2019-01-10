
import { Component, OnInit } from "@angular/core";
import { Fornecedor } from "../shared/models/fornecedor";
import { FornecedorService } from "../shared/services/fornecedor.service";

@Component({
    templateUrl: './fornecedor.component.html',
})
export class FornecedorComponent implements OnInit {

    fornecedores: Array<Fornecedor>;

    constructor(private fornecedorService: FornecedorService) {
        this.fornecedorService.get()
            .subscribe((response: Array<Fornecedor>) => {
                this.fornecedores = response;
            });
    }

    ngOnInit(): void {

    }
}