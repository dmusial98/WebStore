import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ProductsComponent } from './products/products.component';
import { ProductComponent } from './product/product.component';
import { AuthGuard } from './guards/auth-guard.service';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  // { path: 'products', component: ProductsComponent, canActivate: [AuthGuard] },
  // { path: 'products/:categoryName', component: ProductsComponent, canActivate: [AuthGuard] },
  // { path: 'products/:categoryName/:productName', component: ProductComponent, canActivate: [AuthGuard] }
  { path: 'products', component: ProductsComponent },
  { path: 'products/:categoryName', component: ProductsComponent },
  { path: 'products/:categoryName/:productName', component: ProductComponent }
  
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
