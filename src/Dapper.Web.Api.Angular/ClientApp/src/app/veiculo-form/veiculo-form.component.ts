import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Core = require("@angular/core");

@Component({
  selector: 'app-veiculo-form',
  templateUrl: './veiculo-form.component.html'
})
export class VeiculoFormComponent{
  public marcas: marca[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<marca[]>(baseUrl + 'api/marcas').subscribe(result => {
      this.marcas = result;
    }, error => console.error(error));
  }

}

interface modelo {
  id: number;
  nome: string;
  marcaId: number;
}

interface marca {
  id: number;
  nome: string;
  modelos: modelo[];
}
