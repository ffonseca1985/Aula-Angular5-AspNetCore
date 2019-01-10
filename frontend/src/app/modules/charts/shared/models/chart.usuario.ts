import { UteisText } from "../../../../shared/uteis/uteis.text";

export class ChartUsuario {

    constructor(nome:string, sobreNome: string, idade: number) {
        this.nome = nome;
        this.sobreNome = sobreNome;
        this.idade = idade;
    }

    private _nome : string;
    public get nome() : string {
        return this._nome;
    }

    public set nome(v : string) {

        if (UteisText.isNullOrEmpty(v))
            throw "nome não informado"; //excetion em js 

        this._nome = v;
    }
    
    private _sobreNome : string;
    public get sobreNome() : string {
        return this._sobreNome;
    }
    public set sobreNome(v : string) {
            this._sobreNome = v;
    }
    
    private _idade : number;
    public get idade() : number {
        return this._idade;
    }
    public set idade(v : number) {
        this._idade = v;
    }
 
    public get nomeCompleto() : string {
        return this.nome + " " + this.sobreNome;
    }
}
