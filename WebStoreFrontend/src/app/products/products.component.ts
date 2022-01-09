import { Component, OnInit, } from '@angular/core';
import { ProductService } from "src/app/product.service";
import { CategoriesService } from "src/app/categories.service"
import { Subscription } from "rxjs";
import { ActivatedRoute, Router } from "@angular/router";
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
  categoryName: string = null;

  isLoadedCategoryNameFromRoute: boolean = false;
  wasLoadedProductsFromCategory: boolean = false;

  constructor(
    private productService: ProductService,
    private categoriesService: CategoriesService,
    private route: ActivatedRoute,
    private router: Router) {

  }

  ngOnInit(): void {

    console.log('start ngOnInit, categoryName: ', this.categoryName,
      'isLoadedCategoryFromRoute: ', this.isLoadedCategoryNameFromRoute,
      'wasLoadedProductsFromCategory: ', this.wasLoadedProductsFromCategory);

    this.categoryName = this.route.snapshot.paramMap.get('categoryName');

    console.log('categoryName: ', this.categoryName,
      'isLoadedCategoryFromRoute: ', this.isLoadedCategoryNameFromRoute,
      'wasLoadedProductsFromCategory: ', this.wasLoadedProductsFromCategory);

    if (this.categoryName) {
      this.isLoadedCategoryNameFromRoute = true;
      console.log('inside if', 'categoryName: ', this.categoryName,
        'isLoadedCategoryFromRoute: ', this.isLoadedCategoryNameFromRoute,
        'wasLoadedProductsFromCategory: ', this.wasLoadedProductsFromCategory);
    }

    this.categoriesSubscription = this.categoriesService
      .getAllCategories()
      .subscribe(_categories => this.categories = _categories);

    this.productSubscription = this.productService
      .getAllProductsWithOpinions()
      .subscribe(_products => this.products = _products);

    console.log('end ngOnInit', this.categories, this.products);

  }

  ngDoCheck(): void {

    if (this.route.snapshot.paramMap.get('categoryName') != this.categoryName) {
      this.categoryName = this.route.snapshot.paramMap.get('categoryName');

      if (this.categoryName) {
        this.isLoadedCategoryNameFromRoute = true;
        console.log('inside if', 'categoryName: ', this.categoryName,
          'isLoadedCategoryFromRoute: ', this.isLoadedCategoryNameFromRoute,
          'wasLoadedProductsFromCategory: ', this.wasLoadedProductsFromCategory,
          'categories: ', this.categories);
      }

      this.categoriesSubscription = this.categoriesService
        .getAllCategories()
        .subscribe(_categories => this.categories = _categories);

      this.wasLoadedProductsFromCategory = false;
    }

    if (this.isLoadedCategoryNameFromRoute && this.categories && !this.wasLoadedProductsFromCategory) {
      console.log('doCheck ', this.categories, this.isLoadedCategoryNameFromRoute, !this.wasLoadedProductsFromCategory);

      var category = this.categories.find(c => c.namePath === this.categoryName);
      console.log(category);
      var categoryId: number = -1;

      if (category)
        categoryId = category.id;

      console.log('categoryId = ', categoryId);

      this.productSubscription = this.productService
        .getProductsByCategory(categoryId)
        .subscribe(_products => this.products = _products);

      this.wasLoadedProductsFromCategory = true;
    }

  }

  onCategoryChosen(categoryId: number): void {

    if (categoryId < 0) {
      this.goToAllProducts();
    }
    else {
      console.log('mamy id kategorii = ', categoryId);
      var category = this.categories.find(c => c.id == categoryId);

      console.log(category);
      if (category) {
        this.goToProductsByCategory(category.namePath.toLowerCase());
      }
    }
  }

  goToProductsByCategory(newCategoryName: string): void {
    console.log('mamy routing do', newCategoryName);
    this.router.navigate(['products', newCategoryName]);
  }

  goToAllProducts(): void {
    console.log('mamy routing do products');
    this.router.navigate(['products']);
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


  ngOnDestroy(): void {

    if (this.categoriesSubscription)
      this.categoriesSubscription.unsubscribe();

    if (this.productSubscription)
      this.productSubscription.unsubscribe();

  }
}
