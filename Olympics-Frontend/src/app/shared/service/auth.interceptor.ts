import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { UserService } from './user.service';

@Injectable()
export class AuthInterceptor implements AuthInterceptor {
    constructor(private router: Router, private userService: UserService) {}

    private handleAuthError(err: HttpErrorResponse): Observable<any> {
        if (err.status === 401) {
            this.navigateToLogin();
        }
        return throwError(err);
    }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (req.headers.has('Authorization') || this.userService.userSession == null) {
            return next.handle(req);
        }
        const authenticatedRequest = req.clone({
            setHeaders: {
                Authorization: 'Bearer ' + this.userService.userSession.Token,
                'Content-Type': 'application/json',
                Accept: 'application/json',
            },
        });
        console.log(authenticatedRequest);
        return next.handle(authenticatedRequest).pipe(catchError(err => this.handleAuthError(err)));
    }

    private navigateToLogin() {
        this.router.navigateByUrl('/login');
    }
}
