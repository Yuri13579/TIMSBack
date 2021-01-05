import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import {AppService} from './../app.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent implements OnInit {

  salesOrders: any;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getAllSalesOrders();
  }

  // tslint:disable-next-line: typedef
  getAllSalesOrders() {
        this.http.get(environment.apiUrl+'/api/SalesOrderLists')
     .subscribe((response2) => {
    this.salesOrders = response2;
    console.log('getAllCustomers', this.salesOrders);
  } );
}

}
