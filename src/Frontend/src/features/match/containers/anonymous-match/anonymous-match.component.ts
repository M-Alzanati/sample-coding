import { Component, OnInit } from "@angular/core";
import { MessageService } from "primeng/api";
import { UserMatchDto } from "src/core/model/match/user.match.dto";
import { MatchService } from "src/core/services/match.service";

@Component({
    selector: 'app-anonymous-match',
    templateUrl: './anonymous-match.component.html',
    styleUrls: ['./anonymous-match.component.scss'],
})
export class AnonymousMatchComponent implements OnInit {

    matches: UserMatchDto[];

    constructor(private matchService: MatchService, private msgServ: MessageService) {
        
    }

    ngOnInit(): void {
        this.matchService.getPlayedMatches().subscribe(
            data => {
                this.matches = data;
            },
            error => {
                this.msgServ.add({
                    severity: "error",
                    summary: "Error "
                  });
            }
        )
    }
}