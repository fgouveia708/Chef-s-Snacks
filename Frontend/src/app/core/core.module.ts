import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainComponent } from './main/main.component';
import { FooterComponent } from './main/footer/footer.component';
import { CoreRoutingModule } from './core-routing.module';
import { IngredientService } from '../shared/service/ingredient.service';
import { SnackService } from '../shared/service/snack.service';
import { MatButtonModule, MatCheckboxModule } from '@angular/material';


@NgModule({
  imports: [
    CommonModule,
    CoreRoutingModule,
    MatButtonModule,
    MatCheckboxModule,
  ],
  exports: [
    MainComponent
  ],
  providers: [
    IngredientService,
    SnackService,
  ],
  declarations: [
    MainComponent,
    FooterComponent
  ]
})
export class CoreModule { }
