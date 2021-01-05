import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-transfers',
  templateUrl: './transfers.component.html',
  styleUrls: ['./transfers.component.css']
})
export class TransfersComponent implements OnInit {

  transfers: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getAlltransfers();
  }

  // tslint:disable-next-line: typedef
  getAlltransfers() {
        this.http.get(environment.apiUrl+'/api/transfer')
     .subscribe((response2) => {
    this.transfers = response2;
    console.log('getAlltransfers', this.transfers);
  } );
}


}

