
export class Fornecedor 
{
    constructor(id : number, razaoSocial : string) {
        this.id = id;
        this.razaoSocial = razaoSocial;
    }

    private _id : number;
    public get id() : number {
        return this._id;
    }
    public set id(v : number) {
        this._id = v;
    }
    
    private _razaoSocial : string;
    public get razaoSocial() : string {
        return this._razaoSocial;
    }
    public set razaoSocial(v : string) {
        this._razaoSocial = v;
    }
}