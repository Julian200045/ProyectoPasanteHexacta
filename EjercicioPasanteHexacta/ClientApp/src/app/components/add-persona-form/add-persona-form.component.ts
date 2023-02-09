import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { scheduled } from 'rxjs';
import { PersonaDTO } from '../../dtos/persona.dto';
import { PersonaService } from '../../services/persona.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-add-persona-form',
  templateUrl: './add-persona-form.component.html',
  styleUrls: ['./add-persona-form.component.scss']
})
export class AddPersonaFormComponent implements OnInit {

  estadosCiviles = ['Soltero','Casado','Separado','Divorciado','Viudo'] 

  reactiveForm: FormGroup;

  constructor(private personaService: PersonaService) {

  }

  onPersonaAdd()
  {

    if (this.reactiveForm.invalid) {
      return;
    }

    Swal.fire(
      'Persona agregada!',
      '',
      'success'
    )

    let dto = new PersonaDTO(this.reactiveForm.value.nombre, this.reactiveForm.value.apellido, this.reactiveForm.value.edad, this.reactiveForm.value.estadoCivil);

    this.personaService.postPersona(dto).subscribe(data => data);

    this.reactiveForm.reset();
  }

  ngOnInit(): void {
    this.reactiveForm = new FormGroup({

      nombre: new FormControl(null, [Validators.required, Validators.pattern('[a-zA-Z ]*')]),

      apellido: new FormControl(null, [Validators.required, Validators.pattern('[a-zA-Z ]*')]),

      edad: new FormControl(null, [Validators.required, Validators.pattern('[0-9]*'), Validators.min(0)]),

      estadoCivil: new FormControl(null, [Validators.required])

     })

    
  }

}

