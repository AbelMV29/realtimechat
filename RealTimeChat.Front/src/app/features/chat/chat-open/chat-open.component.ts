import { Component, Input } from '@angular/core';
import { Chat } from '../../../core/models/chat';
import { UserService } from '../../../core/services/user.service';
import { Message } from '../../../core/models/message';

@Component({
  selector: 'app-chat-open',
  templateUrl: './chat-open.component.html',
  styleUrl: './chat-open.component.scss'
})
export class ChatOpenComponent {
  @Input() public chatOpen?:Chat | null;
  constructor(private _userService: UserService)
  {

  }

  isMine(id:number) : boolean
  {
    return id == this._userService.getCurrentProfile()?.id
  }

  addMessage(message:Message)
  {
    this.chatOpen?.messages.push(message);
  }
}
