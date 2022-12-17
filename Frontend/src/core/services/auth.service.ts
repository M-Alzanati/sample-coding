import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../environments/environment';
import { LoginDto } from '../model/user/login.dto';
import { BaseService } from './base.service';
import { MessageService } from 'primeng/api';
import { LoginResponseDto } from '../model/user/login.response.dto';

@Injectable({ providedIn: 'root' })
export class AuthService extends BaseService {
    private userSubject: BehaviorSubject<LoginResponseDto> = new BehaviorSubject<LoginResponseDto>({} as LoginResponseDto);

    constructor(private router: Router, private http: HttpClient, private msgServ: MessageService) {
        super();
        const userData = JSON.parse(localStorage.getItem('user') || '{}');
        if (userData) {
            this.userSubject.next(userData);
        }
    }

    public get userValue(): Observable<LoginResponseDto> {
        return this.userSubject.asObservable();
    }

    login(model: LoginDto) {
        return this.http.post<any>(`${environment.apiUrl}/auth/login`, model, this.httpOptions)
            .pipe(map(user => {
                localStorage.setItem('user', JSON.stringify(user));
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