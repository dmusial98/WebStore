import { Component } from '@angular/core';
import { ProductService } from "./product.service";
import { Observable } from 'rxjs';
import { Subscription } from "rxjs";

import { Product } from 'src/app/data/product'


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'WebStoreFrontend';

  productSubscription: Subscription;
  products: Product[];

  constructor(private productService: ProductService) {
  }

  ngOnInit(): void {
    this.productSubscription = this.productService.getAllProducts().subscribe(_products => this.products = _products);
    //this.productSubscription = this.productService.getAllProducts().subscribe(_product => console.log(_product));
  }
}
