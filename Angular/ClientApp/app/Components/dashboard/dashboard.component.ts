import { Component, Inject, OnInit } from '@angular/core';
import { PersonService } from '../../Service/person.service';
import { IPerson } from '../../Models/person';
import { DBOperation } from '../../Shared/enum';
import { Observable } from 'rxjs/Rx';
import { Global } from '../../Shared/global';

@Component({
    selector: 'dashboard',
    templateUrl: './dashboard.component.html'
})
export class DashboardComponent {
    persons: IPerson[];
    person: IPerson;
    dbops: DBOperation;
    currentDate: Date = new Date();
    indLoadingUpcomming: boolean = false;

    constructor(private _personService: PersonService) {

    }

    ngOnInit(): void {
        this.loadUpcommingBirthdays();
    }

    loadUpcommingBirthdays(): void {
        this.indLoadingUpcomming = true;
        console.log(Global.BASE_PERSON_ENDPOINT_Upcomming);
        //this._personService.get("http://localhost:60324/api/person/Upcomming").subscribe(data => { console.log(data); });
        this._personService.post("http://localhost:60324/api/person/Upcomming", 10)
            .subscribe(persons => {
                persons.forEach((item: IPerson) =>
                    item.birthdayToday = (new Date(item.dateOfBirth).getDate() == this.currentDate.getDate() &&
                        new Date(item.dateOfBirth).getMonth() + 1 == this.currentDate.getMonth() + 1));


                this.persons = persons;
                this.indLoadingUpcomming = false;
            },
                (err) => console.log(err));
    }
}
