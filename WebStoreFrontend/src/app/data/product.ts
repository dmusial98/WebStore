import { Opinion }from  "src/app/data/opinion";

export class Product {
  id: number
  name: String
  description: String
  price: number
  currency: String
  amount: number
  opinions: Opinion[]
}
