import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login } from '../auth/login';
import { HttpClient } from '@angular/common/http';
import { Register } from '../auth/register';
import { ServiceResponse } from '../models/service-response';
import { User } from '../models/user';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private _url : string = "https://localhost:7251";
  constructor(private _http:HttpClient, private _cookieService: CookieService) { }

  register(register:Register) : Observable<ServiceResponse<Login>>
  {
    return this._http.post<ServiceResponse<Login>>(`${this._url}/api/users/register`,register);
  }
  login(login:Login) : Observable<ServiceResponse<string>>
  {
    return this._http.post<ServiceResponse<string>>(`${this._url}/api/users/login`,login);
  }
  getUsers(userName: string | null) : Observable<ServiceResponse<User[]>>
  {
    return this._http.get<ServiceResponse<User[]>>(`${this._url}/api/users?userName=${userName}`);
  }
  getUser(userName: string) : Observable<ServiceResponse<User>>
  {
    return this._http.get<ServiceResponse<User>>(`${this._url}/api/users/${userName}`);
  }
  getCurrentProfile(): User | null {
    const token = this._cookieService.get("token");
    if(token)
    {
      const payload = token.split(".")[1];
    const jsonPayload = JSON.parse(window.atob(payload));
    const user : User=
    {
      id: parseInt(jsonPayload['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier']),
      photoUrl: jsonPayload.photoUrl,
      fullName: jsonPayload.name.concat(" ", jsonPayload.lastName),
      userName: jsonPayload.userName
    }
    return user;
    }
    return null;
  }
  logOut() : Observable<ServiceResponse<boolean>>
  {
    return this._http.get<ServiceResponse<boolean>>(`${this._url}/api/users/logout`);
  }
}
