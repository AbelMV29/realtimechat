import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserService } from '../services/user.service';
import { CookieService } from 'ngx-cookie-service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor
{
  constructor(private _userService: UserService, private _cookieService: CookieService)
  {

  }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token: string = this._cookieService.get("token");

    if(token)
    {
      req = req.clone(
        {
          setHeaders: {Authorization: `Bearer ${token}`}
        }
      )
    }
    return next.handle(req);
  }
  
};
