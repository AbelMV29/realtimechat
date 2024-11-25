import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ServiceResponse } from '../models/service-response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {
  private _url : string = "https://localhost:7251";

  constructor(private _http:HttpClient) { }
  //Require Auth
  getNotifications(notificationId: number) : Observable<ServiceResponse<Notification[]>>
  {
    return this._http.get<ServiceResponse<Notification[]>>(`${this._url}/api/notifications`);
  }

}
