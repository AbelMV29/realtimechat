import { ActivatedRouteSnapshot, CanActivate, GuardResult, MaybeAsync, Router, RouterStateSnapshot } from '@angular/router';
import { UserService } from '../services/user.service';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate 
{
  constructor(private _cookieService: CookieService, private _router: Router)
  {

  }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): MaybeAsync<GuardResult> {
    const cookie = this._cookieService.check("token");
    if(!cookie)
      return this._router.navigate(["login"]);
    else
      return true;
  }

}
