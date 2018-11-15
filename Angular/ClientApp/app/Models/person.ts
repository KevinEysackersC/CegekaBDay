export interface IPerson {
    id: string,
    firstName: string,
    name: string,
    dateOfBirth: Date,
    birthdayToday: Boolean,
    managerId: string,
    manager: string
}

export interface IPersons {
    persons: IPerson[]
}