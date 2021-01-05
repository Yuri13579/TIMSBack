import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-purchase-order',
  templateUrl: './purchase-order.component.html',
  styleUrls: ['./purchase-order.component.css']
})
export class PurchaseOrderComponent implements OnInit {

  purchaseOrders: any;
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getAllSalesOrders();
  }

  // tslint:disable-next-line: typedef
  getAllSalesOrders() {
      this.http.get(environment.apiUrl+'/api/PurchaseOrderLists')
      .subscribe((response2) => {
      this.purchaseOrders = response2;
      console.log('getAllCustomers', this.purchaseOrders);
    } );
  }

}
