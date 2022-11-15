import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

import { environment } from '../../environments/environment';
import { UserDto } from '../model/user/user.dto';
import { LoginDto } from '../model/user/login.dto';
import { BaseService } from './base.service';
import { MessageService } from 'primeng/api';
import { LoginResponseDto } from '../model/user/login.response.dto';

@Injectable({ providedIn: 'root' })
export class AuthService extends BaseService {
    private userSubject: BehaviorSubject<LoginResponseDto>;
    public user: Observable<LoginResponseDto>;

    constructor(
        private router: Router,
        private http: HttpClient,
        private msgServ: MessageService
    ) {
        super();
        this.userSubject = new BehaviorSubject<LoginResponseDto>(JSON.parse(localStorage.getItem('user') || '{}'));
        this.user = this.userSubject.asObservable();
    }

    public get userValue(): LoginResponseDto {
        return this.userSubject.value;
    }

    login(model: LoginDto) {
        return this.http.post<any>(`${environment.apiUrl}/auth/login`, model, this.httpOptions)
            .pipe(map(user => {
                localStorage.setItem('token', JSON.stringify(user));
                this.userSubject.next(user);
                return user;
            }));
    }

    logout() {
        localStorage.removeItem('user');
        this.userSubject.next({} as LoginResponseDto);
        this.router.navigate(['/login']);
    }
}