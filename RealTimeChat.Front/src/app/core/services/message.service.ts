import { Injectable } from '@angular/core';
import { MessageSend } from '../form/message-send';
import { Observable } from 'rxjs';
import { ServiceResponse } from '../models/service-response';
import { Message } from '../models/message';
import { HttpClient } from '@angular/common/http';
import { SectionChat } from '../models/section-chat';
import { Chat } from '../models/chat';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  private _url : string = "https://localhost:7251";
  constructor(private _http:HttpClient, private _userService: UserService) {}

  //Require Auth
  sendMessage(message: FormData) : Observable<ServiceResponse<Message>>
  {
    return this._http.post<ServiceResponse<Message>>(`${this._url}/api/messages`,message);
  }
  //Require Auth
  seenMessage(messageId: number) : Observable<ServiceResponse<boolean>>
  {
    return this._http.put<ServiceResponse<boolean>>(`${this._url}/api/messages/seen/${messageId}`,{});
  }
  //Require Auth
  getSectionChats() : Observable<ServiceResponse<SectionChat[]>>
  {
    return this._http.get<ServiceResponse<SectionChat[]>>(`${this._url}/api/messages/chats`);
  }
  //Require Auth
  openChat(destineUserId: number) : Observable<ServiceResponse<Chat>>
  {
    return this._http.get<ServiceResponse<Chat>>(`${this._url}/api/messages/chat/${destineUserId}`);
  }
}
