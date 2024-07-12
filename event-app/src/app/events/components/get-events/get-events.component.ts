import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { EventService } from './../../../events/services/event.services';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-get-events',
  templateUrl: './get-events.component.html',
  styleUrl: './get-events.component.css',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule, HttpClientModule]
})
export class GetEventsComponent {

  events: any = [];
  form: FormGroup = this.fb.group({
    eventType: [''],
    startDate: [''],
    endDate: ['']
  });

  constructor(private eventService: EventService, private fb: FormBuilder) {
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
