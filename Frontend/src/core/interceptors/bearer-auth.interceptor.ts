import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from '../../environments/environment';
import { AuthService } from '../services/auth.service';

@Injectable()
export class BearerAuthInterceptor implements HttpInterceptor {
    constructor(private authService: AuthService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const userValue = this.authService.userValue;
        const isApiUrl = request.url.startsWith(environment.apiUrl);

        if (userValue && isApiUrl) {
            userValue.subscribe(e => {
                request =  request.clone({
                    headers: request.headers.set('Authorization', `Bearer ${e.token}`)
                });
            })
        }
        
        return next.handle(request);
    }
}