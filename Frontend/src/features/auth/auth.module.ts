import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { ButtonModule } from 'primeng/button';
import { MessagesModule } from 'primeng/messages';
import { DropdownModule } from 'primeng/dropdown';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { RadioButtonModule } from 'primeng/radiobutton';
import { CheckboxModule } from 'primeng/checkbox';
import { TooltipModule } from 'primeng/tooltip';

import { CoreModule } from 'src/core/core.module';

import { AuthRoutingModule } from './auth-routing.module';
import * as fromComponents from './components';
import * as fromContainers from './containers';
import { MessageService } from 'primeng/api';

@NgModule({
  declarations: [...fromContainers.containers, ...fromComponents.components],
  providers: [MessageService],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AuthRoutingModule,
    InputTextModule,
    PasswordModule,
    ButtonModule,
    MessagesModule,
    DropdownModule,
    ProgressSpinnerModule,
    RadioButtonModule,
    CheckboxModule,
    TooltipModule,
    CoreModule
  ],
})
export class AuthModule {}
