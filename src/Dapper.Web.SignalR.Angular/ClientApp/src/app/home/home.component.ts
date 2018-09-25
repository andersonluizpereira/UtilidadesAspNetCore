import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  public hubConnection: HubConnection;
  public messages: string[] = [];
  public message: string;

  send() {
    // message sent from the client to the server
    this.hubConnection.invoke("Echo", this.message);
    this.message = "";
  }
  ngOnInit() {
    let builder = new HubConnectionBuilder();

    // as per setup in the startup.cs
    this.hubConnection = builder.withUrl('/hubs/echo').build();

    // message coming from the server
    this.hubConnection.on("Send", (message) => {
      this.messages.push(message);
    });

    // starting the connection
    this.hubConnection.start();
  }

}

