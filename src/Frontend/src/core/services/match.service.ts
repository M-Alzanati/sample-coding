import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../environments/environment';
import { UserMatchDto } from '../model/match/user.match.dto';
import { MatchDto } from '../model/match/match.dto';
import { BaseService } from './base.service';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class MatchService extends BaseService {
    constructor(private http: HttpClient) {super(); }

    getPlayedMatches(): Observable<UserMatchDto[]> {
        return this.http.get<UserMatchDto[]>(`${environment.apiUrl}/match`);
    }

    getCurrentMatch(): Observable<MatchDto> {
        return this.http.get<MatchDto>(`${environment.apiUrl}/match/current`);
    }

    playMatch(matchId: string) : Observable<UserMatchDto> {
        return this.http.post<UserMatchDto>(`${environment.apiUrl}/match/play/${matchId}`, null, this.httpOptions);
    }
}