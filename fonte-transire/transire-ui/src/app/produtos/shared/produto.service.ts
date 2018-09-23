import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

import {Produto} from'./produto.model'

@Injectable()
export class ProdutoService {

  //var URL = "http://localhost:50858/api/Produto";
  selectedProduto : Produto;
  Nome: string;
  produtoList : Produto[];
  constructor(private http : Http) { }

  postProduto(produto : Produto){
    console.log();
    var body = JSON.stringify(produto);
    console.log(body);
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method : RequestMethod.Post,headers : headerOptions});
    return this.http.post('http://localhost:50858/api/produto',body,requestOptions).map(x => x.json());
  }

  pesquisar(){
    var produto = new Produto();
    produto.Nome = this.Nome;
    var body = JSON.stringify(produto);
    console.log(body);
    var headerOptions = new Headers({'Content-Type':'application/json'});
    var requestOptions = new RequestOptions({method : RequestMethod.Post,headers : headerOptions});
    return this.http.post('http://localhost:50858/api/produto/pesquisar',body,requestOptions)
              .map((data : Response) =>{
                return data.json() as Produto[];
              }).toPromise().then(x => {
                console.log(x);
                this.produtoList = x;
              })
  }

  putProduto(id, produto) {
    var body = JSON.stringify(produto);
    var headerOptions = new Headers({ 'Content-Type': 'application/json' });
    var requestOptions = new RequestOptions({ method: RequestMethod.Put, headers: headerOptions });
    return this.http.put('http://localhost:50858/api/produto/' + id,
      body,
      requestOptions).map(res => res.json());
  }
  getProdutoList(){
    this.http.get('http://localhost:50858/api/produto')
    .map((data : Response) =>{
      return data.json() as Produto[];
    }).toPromise().then(x => {
      console.log(x);
      this.produtoList = x;
    })
  }

  deleteProduto(id: number) {
    return this.http.delete('http://localhost:50858/api/produto/' + id).map(res => res.json());
  }
}
