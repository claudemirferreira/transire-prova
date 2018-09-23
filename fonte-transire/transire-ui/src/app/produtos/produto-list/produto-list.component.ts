import { Component, OnInit } from '@angular/core';

import { ProdutoService } from '../shared/produto.service'
import { Produto } from '../shared/produto.model';
import { ToastrService } from 'ngx-toastr';    
@Component({
  selector: 'app-produto-list',
  templateUrl: './produto-list.component.html',
  styleUrls: ['./produto-list.component.css']
})
export class ProdutoListComponent implements OnInit {

  constructor(private produtoService: ProdutoService, private toastr : ToastrService) { }

  ngOnInit() {
    this.produtoService.getProdutoList();
  }
  
  pesquisar(){
    this.produtoService.pesquisar();         
    this.toastr.success('New Record Added Succcessfully', 'Produto Register');
   }

  showForEdit(produtos: Produto) {
    this.produtoService.selectedProduto = Object.assign({}, produtos);;
  }

  onDelete(id: number) {
    if (confirm('Are you sure to delete this record ?') == true) {
      console.log(id);
      this.produtoService.deleteProduto(id)
      .subscribe(x => {
        this.produtoService.getProdutoList();
        this.toastr.warning("Deleted Successfully","produto Register");
      })
    }
  }
}
