export interface IManager {
    id: string,
    firstName: string,
    name: string,
    personId: string,
    personCount: number
}

export interface IManagers {
    managers: IManager[]
}