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
import { CardModule } from 'primeng/card';
import {ScrollPanelModule} from 'primeng/scrollpanel';

import { CoreModule } from 'src/core/core.module';

import { MatchRoutingModule } from './match-routing.module'
import * as fromComponents from './components';
import * as fromContainers from './containers';
import { AnonymousMatchComponent } from './containers/anonymous-match/anonymous-match.component';

@NgModule({
  declarations: [...fromContainers.containers, ...fromComponents.components],
  exports: [AnonymousMatchComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatchRoutingModule,
    InputTextModule,
    PasswordModule,
    ButtonModule,
    MessagesModule,
    DropdownModule,
    ProgressSpinnerModule,
    RadioButtonModule,
    CheckboxModule,
    TooltipModule,
    CoreModule,
    CardModule,
    ScrollPanelModule
  ],
})
export class MatchModule {}
