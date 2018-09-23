import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms'

import { ProdutoService } from '../shared/produto.service'
import { ToastrService } from 'ngx-toastr'
@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit {

  constructor(private produtoService: ProdutoService, private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }


  resetForm(form?: NgForm) {
    console.log("entrou resetForm");
    if (form != null)
      form.reset();
    this.produtoService.selectedProduto = {
      ProdutoID: null,
      Nome: ''
    }
  }

  onSubmit(form: NgForm) {
    
    if (form.value.ProdutoID == null) {
      this.produtoService.postProduto(form.value)
        .subscribe(data => {
          this.resetForm(form);
          this.produtoService.getProdutoList();
          console.log("entrou 2");
          this.toastr.success('New Record Added Succcessfully', 'Produto Register');
        })
    }
    else {
      this.produtoService.putProduto(form.value.ProdutoID, form.value)
      .subscribe(data => {
        this.resetForm(form);
        this.produtoService.getProdutoList();
        this.toastr.info('Record Updated Successfully!', 'Employee Register');
      });
    }
  }
}
