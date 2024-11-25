import { Component } from '@angular/core';
import {faSearch} from '@fortawesome/free-solid-svg-icons';
import { User } from '../../../core/models/user';
import { UserService } from '../../../core/services/user.service';
@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrl: './search.component.scss'
})
export class SearchComponent {
  users : User[] = [];
  faSearch = faSearch;    
  userName: string | null = null;
  onFocus: boolean = false;

  constructor(private _userService: UserService)
  {

  }
  focus()
  {
    this.onFocus = true;
  }
  blur()
  {
    this.onFocus = false;
  }
  searchUsers()
  {
    if(this.userName != null){
      this._userService.getUsers(this.userName).subscribe(dataResponse=>
      {
        if(dataResponse.success)
        {
          console.log(dataResponse.data);
          this.users = dataResponse.data!;
        }
      }
      )
    }
  }
}
