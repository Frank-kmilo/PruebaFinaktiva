import {Component, inject} from '@angular/core';
import {FormBuilder, FormGroup} from "@angular/forms";
import {EventService} from "../../../services/event.service";

@Component({
  selector: 'app-list-events',
  templateUrl: './list-events.component.html',
  styleUrl: './list-events.component.css'
})
export class ListEventsComponent {

  events: any = [];
  form: FormGroup;

  constructor(private eventService: EventService,
              private fb: FormBuilder) {


    this.form = this.fb.group({
      eventType: [''],
      startDate: [''],
      endDate: ['']
    });
  }

  search() {

    const start = this.form.value?.startDate ? new Date(this.form.value?.startDate) : null;
    const end = this.form.value?.endDate ? new Date(this.form.value?.endDate) : null;

    this.eventService.getEventByFilter(this.form.value?.eventType, start, end).subscribe(
      (resp: any[]) => {
        this.events = resp;
      }
    );
  }

}
