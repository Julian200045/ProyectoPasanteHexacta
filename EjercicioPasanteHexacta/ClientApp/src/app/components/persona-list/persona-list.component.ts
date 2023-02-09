import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup} from '@angular/forms';
import { Persona } from '../../models/persona.model'
import { PersonaService } from '../../services/persona.service'

@Component({
  selector: 'app-persona-list',
  templateUrl: './persona-list.component.html',
  styleUrls: ['./persona-list.component.scss']
})
export class PersonaListComponent{

  public listPersonas: Persona[] = [];

  public displayedColumns = ["nombre", "apellido", "edad","grupoEtario","estadoCivil"];

  filterForm: FormGroup;

  constructor(private personaService: PersonaService) { }

  ngOnInit(): void {

    this.filterForm = new FormGroup({

      nombre: new FormControl(""),

      apellido: new FormControl(""),

    })

    this.personaService.getPersonas("", "").subscribe(data => {
      this.listPersonas = data;
    })
  }


  onGetPersonas() {

    this.personaService.getPersonas(this.filterForm.value.nombre, this.filterForm.value.apellido).subscribe(data => {
      this.listPersonas = data;

      console.log(data)
    })
  }
}

