import { Component, OnInit } from '@angular/core';
import { ProductService } from "src/app/product.service";
import { CategoriesService } from "src/app/categories.service"
import { Subscription } from "rxjs";
import { Product } from 'src/app/data/product'
import { Category } from 'src/app/data/category'


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  productSubscription: Subscription;
  categoriesSubscription: Subscription;
  products: Product[];
  categories: Category[];
  sortByDropdownButtonContent: string = 'Cena: najniższa';

  constructor(private productService: ProductService, private categoriesService: CategoriesService) { }

  ngOnInit(): void {
    this.productSubscription = this.productService
      .getAllProductsWithOpinions()
      .subscribe(_products => this.products = _products);
    this.categoriesSubscription = this.categoriesService
      .getAllCategories()
      .subscribe(_categories => this.categories = _categories);
  }

  onCategoryChosen(categoryId: number): void {

    if (categoryId < 0) {
      this.productSubscription = this.productService
        .getAllProductsWithOpinions()
        .subscribe(_products => this.products = _products);
    }

    this.productSubscription = this.productService
      .getProductsByCategory(categoryId)
      .subscribe(_products => this.products = _products);
  }

  onSortProductsClick(sortBy: string): void {

    switch (sortBy) {
      case 'price - growingly':
        {
          this.sortByDropdownButtonContent = 'Cena: najniższa';
          break;
        }
      case 'price - descending':
        {
          this.sortByDropdownButtonContent = 'Cena: najwyższa';
          break;
        }
      case 'mark - growingly':
        {
          this.sortByDropdownButtonContent = 'Ocena: najniższa';
          break;
        }
      case 'mark - descending':
        {
          this.sortByDropdownButtonContent = 'Ocena: najwyższa';
          break;
        }
      case 'amount - growingly':
        {
          this.sortByDropdownButtonContent = 'Ilość: najniższa';
          break;
        }
      case 'amount - descending':
        {
          this.sortByDropdownButtonContent = 'Ilość: najwyższa';
          break;
        }

    }

    this.sortProducts(sortBy);

  }

  sortProducts(sortBy: string): void {

    switch (sortBy) {
      case 'price - descending':
        {
          this.products = this.products.sort((p1, p2) => {
            if (p1.price > p2.price) {
              return -1;
            }
            if (p1.price < p2.price) {
              return 1;
            }
            return 0;
          }
          );
          break;
        }
      case 'price - growingly': {
        this.products = this.products.sort((p1, p2) => {
          if (p1.price > p2.price) {
            return 1;
          }
          if (p1.price < p2.price) {
            return -1;
          }
          return 0;
        }
        );
        break;
      }
      case 'amount - descending': {
        this.products = this.products.sort((p1, p2) => {
          if (p1.amount > p2.amount) {
            return -1;
          }
          if (p1.amount < p2.amount) {
            return 1;
          }
          return 0;
        }
        );
        break;
      }
      case 'amount - growingly': {
        this.products = this.products.sort((p1, p2) => {
          if (p1.amount > p2.amount) {
            return 1;
          }
          if (p1.amount < p2.amount) {
            return -1;
          }
          return 0;
        }
        );
        break;
      }
      case 'mark - descending': {
        this.products = this.products.sort((p1, p2) => {
          if (p1.averageRating > p2.averageRating) {
              return -1;
            }
          if (p1.averageRating < p2.averageRating) {
              return 1;
            }
            return 0;
          }
        );
        break;
      }
      case 'mark - growingly': {
        this.products = this.products.sort((p1, p2) => {
          if (p1.averageRating > p2.averageRating) {
              return 1;
            }
          if (p1.averageRating < p2.averageRating) {
              return -1;
            }
            return 0;
          }
        );
        break;
      }
      default: {
        break;
      }
    }

  }

}
