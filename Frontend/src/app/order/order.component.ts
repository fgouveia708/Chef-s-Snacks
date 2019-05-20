import { Component, OnInit, Directive } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { IngredientService } from '../shared/service/ingredient.service';
import { SnackService } from '../shared/service/snack.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

  customSnack: boolean = false;
  snacks: any[];
  ingredients: any[];
  price: Price;

  constructor(
    private toastr: ToastrService,
    private ingredientService: IngredientService,
    private snackService: SnackService
  ) { }

  ngOnInit() {
    this.getSnacks();
    this.getIngredients();
  }

  save(){
    this.toastr.success("Pedido realizado com sucesso.");
  }

  onKey(event: any, id: string, price: number) {
    var value = event.target.value;

    if(value!=null && value!=0){
    this.ingredients.find(c => c.Id == id).Total = event.target.value * price;
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
        this.toastr.error(error);
      });


  }

  getIngredients() {
    this.ingredientService.get().subscribe(response => {
      this.ingredients = response;
    },
      error => {
        this.toastr.error(error);
      });
  }
  getPrice(id: string, index: number) {
    this.snackService.getPrice(id).subscribe(response => {
      if (response != null)
        this.snacks[index].Price = response;
    },
      error => {
        this.toastr.error(error);
      });
  }
}