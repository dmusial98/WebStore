import { Subscription } from "rxjs";
import { Component, OnInit } from '@angular/core';
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

  constructor(private categoriesService: CategoriesService)
  {}

  ngOnInit(): void
  {
    this.categoriesSubscription = this.categoriesService
      .getAllCategories()
      .subscribe(_categories => this.categories = _categories);
  }

}
