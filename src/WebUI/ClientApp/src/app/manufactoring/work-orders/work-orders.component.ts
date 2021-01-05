import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-work-orders',
  templateUrl: './work-orders.component.html',
  styleUrls: ['./work-orders.component.css']
})
export class WorkOrdersComponent implements OnInit {
  workOrders: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getAllworkOrders();
  }

  // tslint:disable-next-line: typedef
  getAllworkOrders() {
        this.http.get(environment.apiUrl+'/api/workOrder')
     .subscribe((response2) => {
    this.workOrders = response2;
    console.log('getAllworkOrders', this.workOrders);
  } );
}


}

