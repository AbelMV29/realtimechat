import { Component, EventEmitter, Input, Output } from '@angular/core';
import { SectionChat } from '../../../core/models/section-chat';
import { Chat } from '../../../core/models/chat';
import { MessageService } from '../../../core/services/message.service';

@Component({
  selector: 'app-chat-especific',
  templateUrl: './chat-especific.component.html',
  styleUrl: './chat-especific.component.scss'
})
export class ChatEspecificComponent {
  @Input() public chat?: SectionChat
  @Output() chatEvent = new EventEmitter<Chat | null>();
  
  constructor(private _messageService: MessageService)
  {

  }
  selectChat(destineUserId : number)
  {
    this._messageService.openChat(destineUserId).subscribe(dataResponse=>
    {
      if(dataResponse.success)
      {
        this.chatEvent.emit(dataResponse.data);
      }
    })
}
}
