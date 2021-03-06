import { NgModule } from '@angular/core';
import { MainComponent } from './main/main.component';
import { FooterComponent } from './main/footer/footer.component';
import { CoreRoutingModule } from './core-routing.module';
import { IngredientService } from '../shared/service/ingredient.service';
import { SnackService } from '../shared/service/snack.service';
import { NavbarComponent } from './main/navbar/navbar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { HttpClientModule } from '@angular/common/http';
 


@NgModule({
  imports: [
    CoreRoutingModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    HttpClientModule
  
  ],
  exports: [
    MainComponent
  ],
  providers: [
    IngredientService,
    SnackService,
  ],
  declarations: [
    NavbarComponent,
    MainComponent,
    FooterComponent
  ]
})
export class CoreModule { }
