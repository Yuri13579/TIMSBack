import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.css']
})
export class SuppliersComponent implements OnInit {

  suppliers: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getAllSuppliers();
  }

  // tslint:disable-next-line: typedef
  getAllSuppliers() {
        this.http.get(environment.apiUrl+'/api/Supplier')
     .subscribe((response2) => {
    this.suppliers = response2;
    console.log('getAllSuppliers', this.suppliers);
  } );
}


}
