import { Component, OnInit } from "@angular/core";
import { MessageService } from "primeng/api";
import { EmployeeDto } from "src/core/model/employee/employee.dto";
import { EmployeeService } from "src/core/services/employee.service";

@Component({
    selector: 'app-employee',
    templateUrl: './employee.component.html',
    styleUrls: ['./employee.component.scss'],
})
export class EmployeeComponent implements OnInit {

    employees: EmployeeDto[];
    employeeId: string;
    deleteEmployeeId: string;
    employee: EmployeeDto = {} as EmployeeDto;
    createEmployeeDto = {} as EmployeeDto;
    updateEmployeeDto = {} as EmployeeDto;

    constructor(private employeeService: EmployeeService, private msgServ: MessageService) {
    }

    ngOnInit(): void {
        this.getAllEmployees();
    }

    getAllEmployees(): void {
        this.employeeService.getAllEmployees().subscribe(
            data => {
                this.employees = data;
            },
            error => {
                this.msgServ.add({
                    severity: "error",
                    summary: "Error "
                });
            }
        );
    } 

    getEmployeeById(): void {
        this.employeeService.getEmployeeById(this.employeeId).subscribe(
            data => {
                this.employee = data;
            },
            error => {
                this.msgServ.add({
                    severity: "error",
                    summary: "Error "
                });
            }
        );
    }

    createEmployee(): void {
        this.employeeService.createEmployee(this.createEmployeeDto).subscribe(
            data => {
                this.getAllEmployees();
            },
            error => {
                this.msgServ.add({
                    severity: "error",
                    summary: "Error "
                });
            }
        );
    }

    updateEmployee(): void {
        this.employeeService.updateEmployeeById(this.updateEmployeeDto.id, this.updateEmployeeDto).subscribe(
            data => {
                this.getAllEmployees();
            },
            error => {
                this.msgServ.add({
                    severity: "error",
                    summary: "Error "
                });
            }
        );
    }

    deleteEmployeeById(): void {
        this.employeeService.deleteEmployeeById(this.deleteEmployeeId).subscribe(
            data => {
                this.getAllEmployees();
            },
            error => {
                this.msgServ.add({
                    severity: "error",
                    summary: "Error "
                });
            }
        );
    }
}