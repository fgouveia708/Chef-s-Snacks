import { Component, OnInit, Directive } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { IngredientService } from '../shared/service/ingredient.service';
import { SnackService } from '../shared/service/snack.service';
import { PromotionService } from '../shared/service/promotion.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

  customSnack: boolean = false;
  showTotal: boolean = false;
  showCalc: boolean = false;
  snacks: any[];
  ingredients: any[];
  price: Price;
  promotions: any[];
  total: number;

  constructor(
    private toastr: ToastrService,
    private ingredientService: IngredientService,
    private snackService: SnackService,
    private promotionService: PromotionService
  ) { }

  ngOnInit() {
    this.getSnacks();
    this.getPromotion();
    this.getIngredients();
  }

  save() {
    this.toastr.success("Pedido realizado com sucesso.");
  }

  calc() {
    this.getPricePromotionTotal(this.ingredients);
    this.showTotal = true;
  }

  onKey(event: any, id: string) {
    var amount = event.target.value;

    if (amount != null && amount != 0) {

      var ingredient = this.ingredients.find(c => c.Id == id);
      if (ingredient != null) {
        this.getPricePromotion(ingredient, amount);
        ingredient.Amount = amount;
      }

      this.showCalc = true;
    }
  }

  getSnacks() {
    this.snackService.get().subscribe(response => {
      this.snacks = response;

      if (this.snacks.length > 0) {
        for (let index = 0; index < this.snacks.length; index++) {
          this.getPrice(this.snacks[index].Id, index);
        }
      }
    },
      error => {
        this.toastr.error("Erro na comunicação com o servidor.");
      });
  }

  getIngredients() {
    this.ingredientService.get().subscribe(response => {
      this.ingredients = response;
    },
      error => {
        this.toastr.error("Erro na comunicação com o servidor.");
      });
  }

  getPrice(id: string, index: number) {
    this.snackService.getPrice(id).subscribe(response => {
      if (response != null)
        this.snacks[index].Price = response;
    },
      error => {
        this.toastr.error("Erro na comunicação com o servidor.");
      });
  }

  getPricePromotion(ingredient: any, amount: number) {
    this.ingredientService.getPricePromotion(ingredient.Id, amount).subscribe(response => {
      if (response != null) {
        ingredient.SubTotal = response
      }
    },
      error => {
        this.toastr.error("Erro na comunicação com o servidor.");
      });
  }

  getPricePromotionTotal(ingredients: any[]) {

    var total = 0.0;
    ingredients.forEach(element => {
      if (element.SubTotal) {
        total += element.SubTotal;
      }
    });

    var pricePromotion = {
      Ingredients: ingredients,
      Total: total,
    };


    this.ingredientService.getPricePromotionTotal(pricePromotion).subscribe(response => {
      if (response != null) {
        this.total = response;
      }
    },
      error => {
        this.toastr.error("Erro na comunicação com o servidor.");
      });
  }

  getPromotion() {
    this.promotionService.get().subscribe(response => {
      if (response != null)
        this.promotions = response;
    },
      error => {
        this.toastr.error("Erro na comunicação com o servidor.");
      });
  }
}