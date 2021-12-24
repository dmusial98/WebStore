import { Component, OnInit } from '@angular/core';
import { ProductService } from "src/app/product.service";
import { Observable } from 'rxjs';
import { Subscription } from "rxjs";
import { Product } from 'src/app/data/product'


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  productSubscription: Subscription;
  products: Product[];

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.productSubscription = this.productService.getAllProductsWithOpinions().subscribe(_products => this.products = _products);
  }

}
