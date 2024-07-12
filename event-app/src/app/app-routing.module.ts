import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {RegisterEventComponent} from "./pages/event-logs/register-event/register-event.component";
import {ListEventsComponent} from "./pages/event-logs/list-events/list-events.component";

const routes: Routes = [
  {
    path: 'registrar-evento', component: RegisterEventComponent
  },
  {
    path: 'listar-eventos', component: ListEventsComponent
  },
  {
    path: '', redirectTo: '/listar-eventos', pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
