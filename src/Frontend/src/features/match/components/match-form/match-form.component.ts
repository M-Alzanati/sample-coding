import { Component, Input, OnInit } from "@angular/core";

@Component({
    selector: 'app-match-form',
    templateUrl: './match-form.component.html',
    styleUrls: ['./match-form.component.scss'],
})
export class MatchFormComponent implements OnInit {
    @Input() name: string;
    @Input() user: string;
    @Input() value: string;
    @Input() timeStamp: string;

    ngOnInit(): void {
        
    }
}