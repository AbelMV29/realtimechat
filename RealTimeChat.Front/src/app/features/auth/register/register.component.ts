import { Component } from '@angular/core';
import { UserService } from '../../../core/services/user.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Register } from '../../../core/auth/register';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {
  public registerForm: FormGroup;
  constructor(private _userService:UserService, private formBuilder: FormBuilder, 
    private _router: Router)
  {
    this.registerForm = this.formBuilder.group(
      {
        name:['', Validators.required],
        lastName:['', Validators.required],
        userName:['', Validators.required],
        email:['',[Validators.email, Validators.required]],
        password:['', Validators.required],
        confirmPassword:['', Validators.required]
      }
    )
  } 
  signUp()
  {
    if(this.registerForm.valid)
    {
      let userToRegist : Register = this.registerForm.value;

      this._userService.register(userToRegist).subscribe((dataResponse)=>
      {
        if(dataResponse.success){
          this._router.navigate(["/login"]);
          return;
        }
        
      })
    }
    else
    {
      console.log("Mal");
    }
  }

}
