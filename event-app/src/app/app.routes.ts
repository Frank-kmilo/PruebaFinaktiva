import { Component } from '@angular/core';
import { Routes } from '@angular/router';
import { GetEventsComponent } from './events/components/get-events/get-events.component';

export const routes: Routes = [
  {
    path: "",
    component: GetEventsComponent
  }
];
