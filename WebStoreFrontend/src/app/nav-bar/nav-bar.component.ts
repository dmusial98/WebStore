import { Subscription } from "rxjs";
import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";

import { Category } from 'src/app/data/category';
import { CategoriesService } from "src/app/categories.service";

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  categoriesSubscription: Subscription;
  categories: Category[];

  constructor(
    private categoriesService: CategoriesService,
    private router: Router  )
  {}

  ngOnInit(): void
  {
    this.categoriesSubscription = this.categoriesService
      .getAllCategories()
      .subscribe(_categories => this.categories = _categories);
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

  goToAllProducts(): void {
    console.log('mamy routing do products');
    this.router.navigate(['products']);
  }

  goToProductsByCategory(newCategoryName: string): void {
    console.log('mamy routing do', newCategoryName);
    this.router.navigate(['products', newCategoryName]);
  }

}
