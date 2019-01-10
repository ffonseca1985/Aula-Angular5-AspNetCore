
import { TipoTitulo } from "./tipoTitulo";
import {TipoPgto } from './tipoPgto';
import {Parcela } from './parcelas';


export class Titulo {
    
    constructor(tipoTitulo:TipoTitulo, tipoPgto: TipoPgto) {
        this.tipoTitulo = tipoTitulo;
        this.tipoPgto = tipoPgto;
    }

    private _id : number;
    public get id() : number {
        return this._id;
    }
    public set id(v : number) {
        this._id = v;
    }
    
    private _tipoTitulo : TipoTitulo;
    public get tipoTitulo() : TipoTitulo {
        return this._tipoTitulo;
    }
    public set tipoTitulo(v : TipoTitulo) {
        this._tipoTitulo = v;
    }
    
    private _tipoPgto : TipoPgto;
    public get tipoPgto() : TipoPgto {
        return this._tipoPgto;
    }
    public set tipoPgto(v : TipoPgto) {
        this._tipoPgto = v;
    }
    
    private _parcelas : Array<Parcela>;
    public get parcelas() : Array<Parcela> {
        return this._parcelas;
    }
    public set parcelas(v : Array<Parcela>) {
        this._parcelas = v;
    }
    
}
