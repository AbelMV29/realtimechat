import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../core/services/user.service';
import { User } from '../../../core/models/user';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrl: './account.component.scss'
})
export class AccountComponent implements OnInit {
  public user?: User | null;
  constructor(private _userService: UserService, private _router: Router, private _cookieService: CookieService)
  {

  }
  ngOnInit(): void {
    this.user = this._userService.getCurrentProfile();
  }
  
  exit()
  {
    this._userService.logOut().subscribe(dataResponse=>
    {
      if(dataResponse.success)
      {
        this._cookieService.delete("token");
        this._router.navigate(["login"]);
      }
    }
    );
  }
}
