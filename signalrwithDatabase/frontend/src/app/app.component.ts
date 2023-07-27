import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import * as signalR from '@microsoft/signalr';
import { MessageData } from './Models/ChatModels';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
 hubConnection!: signalR.HubConnection;
mess!:MessageData[] ;
 constructor(private http : HttpClient ){
 this.http.get<MessageData[]>("http://localhost:82/api/Rami").subscribe(d=>{
this.mess = d

 })
 }

  createConnection(userId: string) {
    let user_Id = Number(userId)
    this.hubConnection = new signalR.HubConnectionBuilder()
    .withUrl('http://localhost:82/chatsocket?userId=' +user_Id)
    .build();

  this.hubConnection.start()
    .then(() => {
      console.log('SignalR connection started.');
      
    })
    .catch(err => console.error('Error starting SignalR connection:', err));

   
  }


  sendMessage(id: string, mes: string) {
    let Receiver_ID = Number(id);

    this.hubConnection.invoke('SendMessages',mes,Receiver_ID)
    .then(() => {
     
    })
    .catch(err => console.error('Error sending message:', err));




    this.hubConnection.on('ReceiveMessage', (mes: MessageData) => {
      this.mess.push(mes)
  
      

    })
  }


}
