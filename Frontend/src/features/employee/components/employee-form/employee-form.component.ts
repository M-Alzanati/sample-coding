import { Component, Input, OnInit } from "@angular/core";

@Component({
    selector: 'app-employee-form',
    templateUrl: './employee-form.component.html',
    styleUrls: ['./employee-form.component.scss'],
})
export class EmployeeFormComponent implements OnInit {
    @Input() firstName: string;
    @Input() lastName: string;
    @Input() id: string;
    
    ngOnInit(): void {
        
    }
}