import { Component, OnInit } from '@angular/core';
import {variablesGlobales} from '../shared/variablesGlobales';
import {MatTableDataSource} from '@angular/material';
import { UserService } from './../shared/user.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styles: []
})
export class AdminPanelComponent implements OnInit {
  Afiliados;
  accion="";
  formulario:boolean=false;
  formModel = {
    Credito: ''
  }

  displayedColumns: string[] = ['Nombre', 'Apellido', 'Cedula', 'Estado', 'Notificar'];
  dataSource :MatTableDataSource<any>;

  _displayedColumns: string[] = ['Id','Credito'];
  _dataSource :MatTableDataSource<any>;

  constructor(private _variablesGlobales:variablesGlobales, private service: UserService) { }

  ngOnInit() {
    this.service.getAfiliados().subscribe(
      res => {
        this.Afiliados = res;
        console.log(this.Afiliados)
        this.dataSource = new MatTableDataSource(this.Afiliados);
      },
      err => {
        console.log(err);
      },
    );

  }

  reporte(){
    this.accion="reporte"
  }

  notificar(){
    this._variablesGlobales.accion="notificacion"
  }

  nuevoCredito(){
    this.accion="credito"
  }

  nuevo(){
      this.formulario=!this.formulario
  }

  onSubmit(form: NgForm) {debugger
    this.service.crearCredito(form.value).subscribe(
      (res: any) => {
        
        console.log(res)
        
      },
      err => {
          console.log(err)
      }
    );
    debugger
  }

}
