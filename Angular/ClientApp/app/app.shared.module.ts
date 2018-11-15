import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { PersonComponent } from './components/person/person.component';

import { PersonService } from './Service/person.service';
import { MyDatePickerModule } from 'mydatepicker';
import { Ng2Bs3ModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';
import { ManagerComponent } from './Components/manager/manager.component';
import { ManagerService } from './Service/manager.service';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        DashboardComponent,
        PersonComponent,
        ManagerComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
            { path: 'dashboard', component: DashboardComponent },
            { path: 'persons', component: PersonComponent },
            { path: 'managers', component: ManagerComponent },
            { path: '**', redirectTo: 'dashboard' }
        ]),
        MyDatePickerModule,
        Ng2Bs3ModalModule
    ],
    providers: [PersonService, ManagerService],
})
export class AppModuleShared {
}
