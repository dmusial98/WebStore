export class Product {
  id: number
  name: String
  description: String
  price: number
  currency: String
  amount: number

  constructor() {
    this.name = ""
    this.description = ""
    this.currency = ""
    this.id = 0
    this.price = 0
    this.amount = 0
  }
}
