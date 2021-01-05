import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { BehaviorSubject } from 'rxjs';
import { Router } from '@angular/router';
import {Location} from '@angular/common';
import { ToasterService } from 'angular2-toaster';
import { environment } from 'src/environments/environment';
import { User } from './models/user';


@Injectable({
  providedIn: 'root'
})
export class AppService {
  [x: string]: any;

    getToken$ = this.token2;

   // tslint:disable-next-line: max-line-length
   constructor(private http: HttpClient, private router: Router, private location: Location, public readonly toasterService: ToasterService) { }

  // tslint:disable-next-line: typedef
  getToken(token: string) {
    console.warn('getToken', token);
   // this.tokenToShow.next(token);
    localStorage.setItem('currentUser', JSON.stringify({ token: token, name: name }));
  }

  // tslint:disable-next-line: typedef
  getTokenFromlocalStorage() {

    const currentUser = JSON.parse(localStorage.getItem('currentUser'));
    if(currentUser != null){
        return currentUser.token; // your token
      }
  }

  // tslint:disable-next-line: typedef
  login(loginData) {
   console.warn('login to', environment.apiUrl);
   return this.http.post(`${environment.apiUrl}/api/Account`, loginData); ///api/Account
  }

  // tslint:disable-next-line: typedef
  logOut() {
    if (!this.location.isCurrentPathEqualTo('/login')) {
      console.warn('logOut from', this.location);
      // this.tokenToShow.next(null);
      localStorage.setItem('currentUser', JSON.stringify({ token: null, name: name }));
      this.toasterService.pop('success', 'Your are now logged out');
      this.router.navigate(['/login']);
    }
  }

  register(user: User) {
    console.warn('register');
    return this.http.post(`${environment.apiUrl}/api/users/register`, user);
  }


}
