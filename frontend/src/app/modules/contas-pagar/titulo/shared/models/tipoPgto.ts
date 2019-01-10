

export class TipoPgto{
    
    constructor(descricao : string) {
        this.descricao = descricao;
    }
    
    private _id : number;
    public get id() : number {
        return this._id;
    }
    public set id(v : number) {
        this._id = v;
    }
    
    private _descricao : string;
    public get descricao() : string {
        return this._descricao;
    }
    public set descricao(v : string) {
        this._descricao = v;
    }
}