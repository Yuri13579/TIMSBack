import { from } from 'rxjs';
import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree} from '@angular/router';
import { AppService } from './app.service';
import {Observable} from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable()
export class RoleAuthGuard implements CanActivate {

  constructor(private router: Router, private appService: AppService) {
  }

    // tslint:disable-next-line: max-line-length
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean|UrlTree>|Promise<boolean|UrlTree>|boolean|UrlTree {
      const expectedRole = route.data.expectedRole;
      console.warn('expectedRole', expectedRole);
      const token = this.appService.getTokenFromlocalStorage();
    // decode the token to get its payload
      const helper = new JwtHelperService();
      const decodedToken = helper.decodeToken(token);
      console.warn('decodedToken', decodedToken);
      console.warn('decodedToken.role', decodedToken.role);
      if (
        !decodedToken.role.includes(expectedRole)
      // decodedToken.role !== expectedRole
    ) {
      this.router.navigate(['login']);
      return false;
    }
      return true;


  }


}
