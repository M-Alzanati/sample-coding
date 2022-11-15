import { Component, OnInit } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { MessageService } from "primeng/api";
import { MatchDto } from "src/core/model/match/match.dto";
import { UserMatchDto } from "src/core/model/match/user.match.dto";
import { MatchService } from "src/core/services/match.service";

@Component({
    selector: 'app-match',
    templateUrl: './match.component.html',
    styleUrls: ['./match.component.scss'],
})
export class MatchComponent implements OnInit {

    playGameForm: FormGroup;
    matches: UserMatchDto[];
    currentMatch: MatchDto = {} as MatchDto;
    isDisabled: boolean = true;
    randomValue: string;

    constructor(private matchService: MatchService, private msgServ: MessageService) {
        this.playGameForm = new FormGroup({});
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
        );

        this.matchService.getCurrentMatch().subscribe(
            data => {
                if (data) {
                    this.isDisabled = false;
                    this.currentMatch = data;
                }
            },
            error => {
                this.msgServ.add({
                    severity: "error",
                    summary: "Error "
                });
            }
        );
    }

    handleSubmit(event: any) {
        this.matchService.playMatch(this.currentMatch.id).subscribe(
            data => {
                this.isDisabled = true;
                this.randomValue = data.value;
            },
            error => {
                this.msgServ.add({
                    severity: "error",
                    summary: "Error "
                });
            }
        );
    }

    refreshMatchesSubmit(event: any) {
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
        );

        this.matchService.getCurrentMatch().subscribe(
            data => {
                if (data) {
                    this.isDisabled = false;
                    this.currentMatch = data;
                }
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