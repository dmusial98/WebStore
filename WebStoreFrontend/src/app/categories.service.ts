import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Category } from 'src/app/data/category'

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {

  constructor(private http: HttpClient) { }

  getAllCategories(): Observable<Category[]> {
    let token = localStorage.getItem("jwt");

    return this.http.get<Category[]>("http://localhost:5000/api/categories",
      {
        headers: new HttpHeaders({
          "Content-Type": "application/json"
        })
      });
  }
}
