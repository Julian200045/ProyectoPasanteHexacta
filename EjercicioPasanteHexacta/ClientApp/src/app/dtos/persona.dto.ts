export class PersonaDTO {
  public nombre: string;
  public apellido: string;
  public edad: number;
  public estadoCivil: string;

  constructor(nombre: string, apellido: string, edad: number, estadocivil: string) {
      this.nombre = nombre,
      this.apellido = apellido,
      this.edad = edad,
      this.estadoCivil = estadocivil
  }
}
