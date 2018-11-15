import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ManagerService } from '../../Service/manager.service';
import { PersonService } from '../../Service/person.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
import { IManager } from '../../Models/manager';
import { IPerson } from '../../Models/person';
import { DBOperation } from '../../Shared/enum';
import { Observable } from 'rxjs/Rx';
import { Global } from '../../Shared/global';

@Component({
    selector: 'manager',
    templateUrl: './manager.component.html'
})

export class ManagerComponent implements OnInit {
    @ViewChild('Person') elPerson: ElementRef;
    @ViewChild('modal') modal: ModalComponent;
    managers: IManager[] | undefined;
    manager: IManager | undefined;
    msg: string = "";
    indLoading: boolean = false;
    managerFrm: FormGroup;
    dbops: DBOperation | undefined;
    modalTitle: string | undefined;
    modalBtnTitle: string | undefined;
    currentDate: Date = new Date();
    persons: IPerson[] | undefined;

    constructor(private fb: FormBuilder, private _managerService: ManagerService, private _personService: PersonService) {
        this.managerFrm = this.fb.group({
            id: [''],
            personId: ['', Validators.required]
        });
        this.loadManagers();

        this.loadPersons();
    }

    ngOnInit(): void {


    }

    clearDate(): void {
        //this.managerFrm.patchValue();
    }

    loadManagers(): void {
        this.indLoading = true;
        this._managerService.get("http://localhost:60324/api/managers")
            .subscribe(managers => {
                this.managers = managers.managers;
                this.indLoading = false;
                managers.managers.sort((a: any, b: any) => a.name.toLowerCase() > b.name.toLowerCase() ? 1 : -1);
            },
                error => this.msg = <any>error);
    }

    loadPersons(): void {
        this._personService.get("http://localhost:60324/api/persons")
            .subscribe(persons => {
                this.persons = persons.persons;
                this.indLoading = false;
                persons.persons.sort((a: any, b: any) => a.name.toLowerCase() > b.name.toLowerCase() ? 1 : -1);
            },
                error => this.msg = <any>error);

        
    }

    setControlsState(isEnable: boolean) {
        isEnable ? this.managerFrm.enable() : this.managerFrm.disable();
    }

    addManager() {
        this.dbops = DBOperation.create;
        this.setControlsState(true);
        this.modalTitle = "Add New Manager";
        this.modalBtnTitle = "Add";
        this.managerFrm.reset();
        this.modal.open();
    }

    onOpen() {
        setTimeout(() => {
            this.elPerson.nativeElement.focus();
        });
    }

    editManager(id: string) {
        this.dbops = DBOperation.update;
        this.setControlsState(true);
        this.modalTitle = "Edit Manager";
        this.modalBtnTitle = "Update";
        this.manager = this.managers != undefined ? this.managers.filter(x => x.id == id)[0] : undefined;
        if (this.manager != undefined) {
            this.managerFrm.patchValue(this.manager);
        }
        this.modal.open();

    }

    deleteMAnager(id: string) {
        this.dbops = DBOperation.delete;
        this.setControlsState(false);
        this.modalTitle = "Confirm to Delete?";
        this.modalBtnTitle = "Delete";
        this.manager = this.managers != undefined ? this.managers.filter(x => x.id == id)[0] : undefined;
        if (this.manager != undefined) {
            this.managerFrm.setValue(this.manager);
        }
        this.modal.open();
    }

    onSubmit(formData: any) {
        this.msg = "";

        //console.log(formData._value);

        switch (this.dbops) {
            case DBOperation.create:
                this._managerService.post("http://localhost:60324/api/managers", formData._value).subscribe(
                    data => {
                        if (data != null) //Success
                        {
                            this.msg = "Data successfully added.";
                            this.loadManagers();
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
            //case DBOperation.update:
            //    this._managerService.put("http://localhost:60324/api/managers/", formData._value.id, formData._value).subscribe(
            //        data => {
            //            if (data != null) //Success
            //            {
            //                this.msg = "Data successfully updated.";
            //                this.loadManagers();
            //            }
            //            else {
            //                this.msg = "There is some issue in saving records, please contact to system administrator!"
            //            }

            //            this.modal.dismiss();
            //        },
            //        error => {
            //            this.msg = error;
            //        }
            //    );
            //    break;
            case DBOperation.delete:
                this._managerService.delete("http://localhost:60324/api/managers/", formData._value.id).subscribe(
                    data => {
                        if (data == null) //Success
                        {
                            this.msg = "Data successfully deleted.";
                            this.loadManagers();
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