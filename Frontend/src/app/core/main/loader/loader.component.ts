import { Component, OnInit } from '@angular/core';
import { LoaderService } from 'src/app/shared/service/loader.service';

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.scss']
})
export class LoaderComponent implements OnInit {

  public showLoader: boolean = false;

  constructor(private loaderService: LoaderService) { }

  ngOnInit() {
    this.loaderService.showLoader.subscribe(showLoader =>{
      this.showLoader = showLoader;
    });
  }

}
