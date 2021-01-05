import { environment } from 'src/environments/environment';
import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {

  customers: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getAllCustomers();
  }

  // tslint:disable-next-line: typedef
  getAllCustomers() {
        this.http.get(environment.apiUrl+'/api/Customer')
     .subscribe((response2) => {
    this.customers = response2;
    console.log('getAllCustomers', this.customers);
  } );
}


}
