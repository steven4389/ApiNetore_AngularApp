import { Injectable } from '@angular/core';

@Injectable()
export class variablesGlobales{

    public accion:string
    
    
    constructor(){}

    getReporte(){
        let data = this.accion
        this.accion=null
        return data
    }
}