import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/core/guards';
import { AuthLayoutComponent } from 'src/core/containers/auth-layout/auth-layout.component';
import { MainLayoutComponent } from 'src/core/containers/main-layout/main-layout.component';
import { MatchComponent } from 'src/features/match/containers/match/match.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: '/login',
  },
  {
    path: '',
    component: AuthLayoutComponent,
    loadChildren: () =>
      import('src/features/auth/auth.module').then((m) => m.AuthModule),
  },
  {
    path: '',
    component: MainLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: 'match',
        component: MatchComponent
      }
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
