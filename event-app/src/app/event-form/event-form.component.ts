import { Component, OnInit } from '@angular/core';
import { EventService } from '../event.service';

@Component({
  selector: 'app-event-form',
  templateUrl: './event-form.component.html',
  styleUrls: ['./event-form.component.css']
})
export class EventFormComponent implements OnInit {

  eventType: string = '';
  eventDate: Date = new Date();
  eventDescription: string = '';

  constructor(private eventService: EventService) { }

  ngOnInit(): void {
  }

  onSubmit(): void {
    const eventData = {
      eventType: this.eventType,
      eventDate: this.eventDate,
      eventDescription: this.eventDescription
    };

    this.eventService.saveEvent(eventData).subscribe(response => {
      console.log('Evento guardado exitosamente:', response);
    }, error => {
      console.error('Error al guardar el evento:', error);
    });
  }
}
