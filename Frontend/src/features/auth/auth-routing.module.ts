import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { NotAuthGuard } from 'src/core/guards';
import { LoginComponent } from './containers/login/login.component';


const routes: Routes = [
  {
    path: 'login',
    canActivate: [NotAuthGuard],
    component: LoginComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AuthRoutingModule {}
