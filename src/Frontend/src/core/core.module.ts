import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ConfirmationService, MessageService } from 'primeng/api';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { MenuModule } from 'primeng/menu';
import { PanelMenuModule } from 'primeng/panelmenu';
import { AvatarModule } from 'primeng/avatar';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { BlockUIModule } from 'primeng/blockui';

import * as fromContainers from './containers';
import * as fromComponents from './components';
import * as fromInterceptros from './interceptors';

@NgModule({
    declarations: [
        ...fromContainers.containers,
        ...fromComponents.components,
    ],
    providers: [MessageService, ConfirmationService, ...fromInterceptros.interceptors],
    exports: [
        ...fromContainers.containers,
        ...fromComponents.components
      ],
    imports: [
        CommonModule,
        RouterModule,
        FormsModule,
        ReactiveFormsModule,
        ButtonModule,
        DropdownModule,
        MenuModule,
        PanelMenuModule,
        AvatarModule,
        ConfirmDialogModule,
        BlockUIModule
    ],
})
export class CoreModule { }
