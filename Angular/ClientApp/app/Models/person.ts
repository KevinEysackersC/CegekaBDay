export interface IPerson {
    id: string,
    firstName: string,
    name: string,
    dateOfBirth: Date,
    birthdayToday: Boolean
}

export interface IPersons {
    persons: IPerson[]
}