import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import  jwt_decode from 'jwt-decode';
import {ToasterService} from 'angular2-toaster';
import {AppService} from './../app.service';
import { LoginResponse } from './../app.models';
import {catchError} from 'rxjs/operators';
import { of, throwError } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  postData = {
    userName: 'administrator@localhost',
    password: 'Olena2206!'
  };
  loginPost: string;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';
  jwtHelper: JwtHelperService = new JwtHelperService();
  constructor(private http: HttpClient,
              public readonly toasterService: ToasterService,
              private readonly appService: AppService,
              private router: Router
              ) {

  }

  ngOnInit() {}

  postLogin() {
    this.appService.login(this.postData)
    .pipe(
      catchError(err => {
        of(this.toasterService.pop('error', err.error, `something happening`));
        return throwError(err);
    })
     )
    .subscribe((res: LoginResponse) => {
    if ( (res.token === 'Password isn\'t valid') || (res.token ===  'User isn\'t found')) {
        this.toasterService.pop('info', res.token);
    } else {
      this.appService.getToken(res.token);
      console.log('success', 'Login succesfull');
      //this.toasterService.pop('success', 'Login succesfull');
      this.router.navigate(['/customerPortalComponent']);
      const decodeAuthToken = this.jwtHelper.decodeToken(res.token);
      console.warn('decodeAuthToken', decodeAuthToken);
  }
    });

  }

  getDecodedAccessToken(token: string): any {
    try{
        return jwt_decode(token);
    }
    catch(Error){
        return null;
    }
  }

}
