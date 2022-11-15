import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthGuard } from 'src/core/guards';
import { MatchComponent } from './containers/match/match.component';


const routes: Routes = [
  {
    path: 'match',
    canActivate: [AuthGuard],
    component: MatchComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MatchRoutingModule {}
