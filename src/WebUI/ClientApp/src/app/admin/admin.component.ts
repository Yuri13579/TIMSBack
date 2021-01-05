import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  users: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getAllUsers();
  }

  // tslint:disable-next-line: typedef
  getAllUsers() {
        this.http.get(environment.apiUrl+'/api/Users')
     .subscribe((response2) => {
    this.users = response2;
    console.log('getAllCustomers', this.users);
  } );
}

}
