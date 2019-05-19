import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

  constructor(private toastr: ToastrService) { }

  ngOnInit() {
    var ss = 1;
   this.success();
  }
success()
{
  this.toastr.success('Hello world!', 'Toastr fun!');
}
}
