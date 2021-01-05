import { from } from 'rxjs';
import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import {AppService } from './app.service';
import {Observable} from 'rxjs';

@Injectable()
export class AuthGuard implements CanActivate {

  constructor(private router: Router, private appService: AppService) {
  }

  // tslint:disable-next-line: max-line-length
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean|UrlTree>|Promise<boolean|UrlTree>|boolean|UrlTree {
    let currentUser = '';
    const res = this.appService.getTokenFromlocalStorage();
    // this.appService.getToken$.subscribe(res =>{
      if (res) {
        currentUser = res;
      }
    // }) ;

    console.warn('currentUser', currentUser);
    if (currentUser) {
      console.warn('intercept', currentUser);
      return true;
      } else {
      this.router.navigate(['/login']);
      return false;
    }

  }


}
