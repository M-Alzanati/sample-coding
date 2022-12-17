import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AuthGuard } from 'src/core/guards';
import { EmployeeComponent } from './containers/employee/employee.component';


const routes: Routes = [
  {
    path: 'employee',
    canActivate: [AuthGuard],
    component: EmployeeComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EmployeeRoutingModule {}
