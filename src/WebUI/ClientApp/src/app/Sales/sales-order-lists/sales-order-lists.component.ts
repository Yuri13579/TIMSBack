import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-sales-order-lists',
  templateUrl: './sales-order-lists.component.html',
  styleUrls: ['./sales-order-lists.component.css']
})
export class SalesOrderListsComponent implements OnInit {

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
