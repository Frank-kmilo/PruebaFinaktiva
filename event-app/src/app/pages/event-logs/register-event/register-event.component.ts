import { Component } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {EventService} from "../../../services/event.service";

@Component({
  selector: 'app-register-event',
  templateUrl: './register-event.component.html',
  styleUrl: './register-event.component.css'
})
export class RegisterEventComponent {

  form: FormGroup;
  constructor(private fb: FormBuilder,
              private eventService: EventService) {

    this.form = this.fb.group({
      type: ['',[Validators.required]],
      eventDate: ['',[Validators.required]],
      eventDescription: ['',[Validators.required]],
    });
  }

  addEvent(){
    let event= {
      eventType: this.form.value?.type,
      eventDate: this.form.value?.eventDate,
      eventDescription: this.form.value?.eventDescription
    }

    this.eventService.saveEvent(event).subscribe((resp)=>{
      alert(resp);
    });
  }

}
