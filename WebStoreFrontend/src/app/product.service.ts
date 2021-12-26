import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from'@angular/common/http';
import { Observable } from 'rxjs';

import { Product } from 'src/app/data/product'

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient) { }

  getAllProductsWithOpinions(): Observable<Product[]> {
    let token = localStorage.getItem("jwt");

    return this.http.get<Product[]>("http://localhost:5000/api/products",
      {
        headers: new HttpHeaders({
          "Content-Type": "application/json"
        })
      });
  }

  getProductsByCategory(categoryId: number): Observable<Product[]> {
    let token = localStorage.getItem("jwt");

    return this.http.get<Product[]>(`http://localhost:5000/api/products/byCategory?categoryId=${categoryId}`,
      {
        headers: new HttpHeaders({
          "Content-Type": "application/json"
        })
      });
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(`http://localhost:5000/api/products/${id}`);
  }

}
