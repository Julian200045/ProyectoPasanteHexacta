import { Injectable } from '@angular/core'
import { Persona } from '../models/persona.model'
import { HttpClient, HttpParams } from '@angular/common/http'
import { environment } from '../../environments/environment'
import { PersonaDTO } from '../dtos/persona.dto';
import { catchError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  constructor(
    private http: HttpClient,
  ) { }

  url = environment.baseUrl + '/api/persona';

  getPersonas(nombre: string, apellido: string) {

    let params = new HttpParams;
    params = params.append("nombre", nombre);
    params = params.append("apellido", apellido);

    return this.http.get<Persona[]>(this.url, { params:params })
  }


  postPersona(personadto: PersonaDTO) {

    return this.http.post<PersonaDTO>(this.url, personadto);
  }
}
