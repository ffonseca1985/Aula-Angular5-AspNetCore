

export class Tenant {
    
    private _nome : string;
    public get nome() : string {
        return this._nome;
    }
    public set nome(v : string) {
        this._nome = v;
    }
    
    private _id : string;
    public get id() : string {
        return this._id;
    }
    public set id(v : string) {
        this._id = v;
    }
}