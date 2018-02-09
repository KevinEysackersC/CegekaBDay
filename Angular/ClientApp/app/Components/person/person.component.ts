import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { PersonService } from '../../Service/person.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
import { IPerson } from '../../Models/person';
import { DBOperation } from '../../Shared/enum';
import { Observable } from 'rxjs/Rx';
import { Global } from '../../Shared/global';
import { IMyDpOptions } from 'mydatepicker';

@Component({
    selector: 'person',
    templateUrl: './person.component.html'
})

export class PersonComponent implements OnInit {
    @ViewChild('FirstName') elFirstName: ElementRef;
    @ViewChild('modal') modal: ModalComponent;
    persons: IPerson[];
    person: IPerson;
    msg: string;
    indLoading: boolean = false;
    personFrm: FormGroup;
    dbops: DBOperation;
    modalTitle: string;
    modalBtnTitle: string;
    currentDate: Date = new Date();

    constructor(private fb: FormBuilder, private _personService: PersonService) {

    }

    public myDatePickerOptions: IMyDpOptions = {
        dateFormat: 'dd-mm-yyyy',
        disableSince: { year: this.currentDate.getFullYear(), month: this.currentDate.getMonth() + 1, day: this.currentDate.getDate() + 1 }
    };

    ngOnInit(): void {
        this.personFrm = this.fb.group({
            id: [''],
            firstName: ['', Validators.required],
            name: ['', Validators.required],
            dateOfBirth: ['', Validators.required]
        });
        this.loadPersons();
    }

    setDate(date: Date): void {
        this.personFrm.patchValue({
            dateOfBirth: {
                date: {
                    year: date.getFullYear(),
                    month: date.getMonth() + 1,
                    day: date.getDate()
                }
            }
        });
    }

    clearDate(): void {
        this.personFrm.patchValue({ dateOfBirth: null });
    }

    loadPersons(): void {
        this.indLoading = true;
        this._personService.get("http://localhost:60324/api/person/GetAll")
            .subscribe(persons => { this.persons = persons; this.indLoading = false; this.persons.sort((a, b) => a.name.toLowerCase() > b.name.toLowerCase() ? 1 : -1); },
            error => this.msg = <any>error);


    }

    setControlsState(isEnable: boolean) {
        isEnable ? this.personFrm.enable() : this.personFrm.disable();
    }

    addPerson() {
        this.dbops = DBOperation.create;
        this.setControlsState(true);
        this.modalTitle = "Add New Person";
        this.modalBtnTitle = "Add";
        this.personFrm.reset();
        this.modal.open();
    }

    onOpen() {
        setTimeout(() => {
            this.elFirstName.nativeElement.focus();
        });
    }

    editPerson(id: string) {
        this.dbops = DBOperation.update;
        this.setControlsState(true);
        this.modalTitle = "Edit Person";
        this.modalBtnTitle = "Update";
        this.person = this.persons.filter(x => x.id == id)[0];
        this.personFrm.setValue(this.person);
        this.setDate(new Date(this.person.dateOfBirth));
        this.modal.open();

    }

    deletePerson(id: string) {
        this.dbops = DBOperation.delete;
        this.setControlsState(false);
        this.modalTitle = "Confirm to Delete?";
        this.modalBtnTitle = "Delete";
        this.person = this.persons.filter(x => x.id == id)[0];
        this.personFrm.setValue(this.person);
        this.modal.open();
    }

    onSubmit(formData: any) {
        this.msg = "";
        if (formData.value.dateOfBirth.date != undefined) {
            formData.value.dateOfBirth = formData.value.dateOfBirth.date.year.toString() +
                "-" +
                formData.value.dateOfBirth.date.month.toString() +
                "-" +
                formData.value.dateOfBirth.date.day.toString();
        }

        console.log(formData._value);

        switch (this.dbops) {
            case DBOperation.create:
                this._personService.post("http://localhost:60324/api/person/Create", formData._value).subscribe(
                    data => {
                        if (data != null) //Success
                        {
                            this.msg = "Data successfully added.";
                            this.loadPersons();
                        }
                        else {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }
                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;
            case DBOperation.update:
                this._personService.put("http://localhost:60324/api/person/Update/", formData._value.id, formData._value).subscribe(
                    data => {
                        if (data != null) //Success
                        {
                            this.msg = "Data successfully updated.";
                            this.loadPersons();
                        }
                        else {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }

                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;
            case DBOperation.delete:
                this._personService.delete("http://localhost:60324/api/person/Delete/", formData._value.id).subscribe(
                    data => {
                        if (data == null) //Success
                        {
                            this.msg = "Data successfully deleted.";
                            this.loadPersons();
                        }
                        else {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }

                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;

        }
    }
}