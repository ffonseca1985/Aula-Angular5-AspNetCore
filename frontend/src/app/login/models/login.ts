import { UteisText } from "../../shared/uteis/uteis.text";

export class Login {

    constructor(userName: string, password : string) {
        this.userName = userName;
        this.password = password;
    }
    
    private _userName : string;
    public get userName() : string {
        return this._userName;
    }
    public set userName(v : string) {
        this._userName = v;
    }
       
    private _password : string;
    public get password() : string {
        return this._password;
    }
    public set password(v : string) {
        this._password = v;
    }

    isValid(){
        if (UteisText.isNullOrEmpty(this.password) || UteisText.isNullOrEmpty(this.userName))
        return false;

        return true
    }
    
}