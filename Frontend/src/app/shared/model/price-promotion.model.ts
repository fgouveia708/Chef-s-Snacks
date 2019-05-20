interface PricePromotion {
    Ingredients: Ingredient[];
    Total: number;
  }
  
  interface Ingredient {
    Name: string;
    Price: number;
    Promotion: number;
    Id: string;
  }