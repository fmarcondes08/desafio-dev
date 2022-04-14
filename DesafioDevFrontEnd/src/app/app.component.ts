import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'DesafioDevFrontEnd';
  data = [];

  send(event: any) {
    this.data = event;
  }

  newProcess(){
    this.data = [];
  }
}
