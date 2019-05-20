interface Snack {
  Name: string;
  Ingredients: Ingredient[];
  Id: string;
  Price: Price;
}

interface Price {
  Price: number;
  PriceFormat: string;
}