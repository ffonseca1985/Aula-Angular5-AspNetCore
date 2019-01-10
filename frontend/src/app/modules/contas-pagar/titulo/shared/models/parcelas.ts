
export class Parcela 
{
    constructor(dataVencimento:Date, valor: number, dataPgto : Date) {
        this.dataPgto =  dataPgto;
        this.dataVencimento = dataVencimento,
        this.valor = valor;
    }
    
    private _dataVencimento : Date;
    public get dataVencimento() : Date {
        return this._dataVencimento;
    }
    public set dataVencimento(v : Date) {
        this._dataVencimento = v;
    }
    
    private _valor : number;
    public get valor() : number {
        return this._valor;
    }
    public set valor(v : number) {
        this._valor = v;
    }   
    
    private _dataPgto    : Date;
    public get dataPgto () : Date {
        return this._dataPgto   ;
    }
    public set dataPgto (v : Date) {
        this._dataPgto   = v;
    }
    
}


