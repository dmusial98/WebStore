import { Component, OnInit } from '@angular/core';
import { ProductService } from "src/app/product.service";
import { CategoriesService } from "src/app/categories.service"
import { Subscription } from "rxjs";
import { ActivatedRoute, Router } from "@angular/router";
import { Product } from 'src/app/data/product'
import { Opinion } from 'src/app/data/opinion'
import { Category } from 'src/app/data/category'
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  constructor(
    private productService: ProductService,
    private categoriesService: CategoriesService,
    private route: ActivatedRoute,
    private router: Router) { }


  productSubscription: Subscription;
  categorySubscription: Subscription;
  product: Product;
  opinions: Opinion[];
  products: Product[];
  category: Category;
  categories: Category[];
  productNameFromRoute: string;
  categoryNameFromRoute: string;

  wasLoadedProduct: boolean = false;

  ngOnInit(): void {

    this.categoryNameFromRoute = this.route.snapshot.paramMap.get('categoryName');
    this.productNameFromRoute = this.route.snapshot.paramMap.get('productName');

    // console.log(this.categoryNameFromRoute, this.productNameFromRoute);

    this.categorySubscription = this.categoriesService
      .getAllCategories().subscribe(
        _categories => this.categories = _categories);

    this.productSubscription = this.productService.getAllProductsWithOpinions()
      .subscribe(_products => this.products = _products);
  }

  ngDoCheck(): void {

    if (this.categories && this.products && !this.wasLoadedProduct) {

      this.category = this.categories.find(c => c.namePath === this.categoryNameFromRoute);
      this.product = this.products.find(p => p.namePath === this.productNameFromRoute);

      if (!this.category || !this.product) {
        console.log('something went wrong');

        //TODO: make routing to 404 not found
      }

      if (this.product.opinions.length != 0)
        this.opinions = this.product.opinions;
      console.log('this.category = ', this.category, 'this.product = ', this.product, 'opinions = ', this.opinions);



      this.wasLoadedProduct = true;
    }
  }

}
