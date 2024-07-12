import { GetEventsComponent } from './events/components/get-events/get-events.component';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule, RouterOutlet, provideRouter } from '@angular/router';
import { appConfig } from './app.config';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, HttpClientModule,GetEventsComponent,RouterModule],
  templateUrl: './app.component.html',
  //providers: [appConfig.providers],
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'event-app';
}
