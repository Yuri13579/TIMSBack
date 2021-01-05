import { AppService } from './app.service';
import {Injectable} from '@angular/core';
import {HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Observable, throwError, of} from 'rxjs';
import {ToasterService} from 'angular2-toaster';
import {catchError} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class TokenInterception implements HttpInterceptor {

  constructor( private tS: ToasterService, private appService: AppService) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const res = this.appService.getTokenFromlocalStorage();
    // this.appService.getToken$.subscribe(res => {
    if (res) {
      console.warn('intercept', res);
      request = this.addToken(request, res);
    }
    // });

    return next.handle(request).pipe(
      catchError(error => {
        if (error instanceof HttpErrorResponse && error.status === 401) {
          // this.authService.logout();
        } else {
          of(this.tS.pop('error', `${error.error ? error.error : error.statusText}`, 'Please try again'));
          return throwError(error);
        }
      }));
  }

  private addToken(request: HttpRequest<any>, token: string) {
    return request.clone({
      setHeaders: {
        'Authorization': `Bearer ${token}`
      },
    });
  }
}
