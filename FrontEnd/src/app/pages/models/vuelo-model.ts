/**
 * @description: Interfaz representante del vuelo
 */
export interface VueloModel {
    numVuelo: number,
    BC_ID:number,
    placaAvion: number,
    capacidad: number,
    numMaletas: number,
    origen: string,
    destino: string
}
