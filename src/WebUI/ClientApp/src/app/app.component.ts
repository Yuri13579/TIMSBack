import { Component } from '@angular/core';
import { AppService } from './app.service';
import { HttpClient } from '@angular/common/http';
import {ToasterConfig} from 'angular2-toaster';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'TIMSFront';
  userName: number;
  response: any;
  loginCheck: boolean;

  constructor(private http: HttpClient, private appService: AppService){
    this.checkToken();
  }

  public config: ToasterConfig =
  new ToasterConfig({
    positionClass: 'toast-top-right',
    showCloseButton: true,
    animation: 'fade'
  });

  search() {
    this.http.get('https://localhost:44394/api/Product/GetSaleOrderById/'+ this.userName)
       .subscribe((response) => {
      this.response = response;
      console.log(this.response);
    });
  }

  checkToken() {
      // this.appService.getToken$.subscribe(res =>{
        const res = this.appService.getTokenFromlocalStorage();
        if (res) {
          this.loginCheck = true;
        } else {
          this.loginCheck = false;
        }
        console.warn('loginCheck', this.loginCheck);
    // }) ;

  }
}
