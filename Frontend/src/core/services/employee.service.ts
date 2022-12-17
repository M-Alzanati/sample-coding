import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { EmployeeDto } from '../model/employee/employee.dto';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class EmployeeService extends BaseService {
    constructor(private http: HttpClient) {super(); }

    getAllEmployees(): Observable<EmployeeDto[]> {
        return this.http.get<EmployeeDto[]>(`${environment.apiUrl}/employee`, this.httpOptions);
    }

    getEmployeeById(id: string): Observable<EmployeeDto> {
        return this.http.get<EmployeeDto>(`${environment.apiUrl}/employee/${id}`, this.httpOptions);
    }

    createEmployee(employeeDto: EmployeeDto) : Observable<EmployeeDto> {
        return this.http.post<EmployeeDto>(`${environment.apiUrl}/employee`, JSON.stringify(employeeDto), this.httpOptions);
    }

    updateEmployeeById(id: string, employeeDto: EmployeeDto): Observable<EmployeeDto> {
        return this.http.put<EmployeeDto>(`${environment.apiUrl}/employee/${id}`, JSON.stringify(employeeDto), this.httpOptions);
    }

    deleteEmployeeById(id: string): Observable<EmployeeDto> {
        return this.http.delete<EmployeeDto>(`${environment.apiUrl}/employee/${id}`, this.httpOptions);
    }
}