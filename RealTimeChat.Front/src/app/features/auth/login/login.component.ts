import { Component, OnInit } from '@angular/core';
import { Login } from '../../../core/auth/login';
import { UserService } from '../../../core/services/user.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit {
  public loginForm: FormGroup;
  constructor(private _userService: UserService, private formBuilder: FormBuilder, 
    private _router: Router, private _cookieService: CookieService)
  {
    this.loginForm = this.formBuilder.group(
      {
        email:['',[Validators.email, Validators.required]],
        password:['', Validators.required]
      }
    )
  } 
  ngOnInit(): void {
    this._userService.getCurrentProfile();
  }
  login()
  {
    if(this.loginForm.valid)
    {
      let userToLogin : Login = this.loginForm.value;

      this._userService.login(userToLogin).subscribe((dataResponse)=>
      {
        if(dataResponse.success){
          this._cookieService.set("token", dataResponse.data!);
          this._router.navigate(["chat"]);
        }
        
      })
    }
    else
    {
      console.log("Mal");
    }
  }
}
