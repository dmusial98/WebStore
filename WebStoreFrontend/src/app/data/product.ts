import { Opinion }from  "src/app/data/opinion";
import { Category } from "src/app/data/category"

export class Product {
  id: number
  category: Category
  name: String
  description: String
  price: number
  currency: String
  amount: number
  averageRating: number
  opinions: Opinion[]
}
