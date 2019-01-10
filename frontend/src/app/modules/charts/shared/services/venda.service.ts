
import { Injectable } from "@angular/core";
import { Http } from "@angular/http"; // toda requisição usada para conectar-se com uma api
//usaremos esta classe

//O que é um service??
//R. Uma classe se irá conectar-se com as apis!!!
@Injectable() //=> serve para ser injetado e criado no contrutos das classes sem a necessidade
// de instanciá-lo
export class VendaService {

    //o http é um serivice, porque ele não precisa ser instanciado!!!
    constructor(http: Http) {
    }

}