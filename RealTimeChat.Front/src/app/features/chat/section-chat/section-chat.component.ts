import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { SectionChat } from '../../../core/models/section-chat';
import { Message } from '../../../core/models/message';
import { User } from '../../../core/models/user';
import { MessageService } from '../../../core/services/message.service';
import { Chat } from '../../../core/models/chat';

@Component({
  selector: 'app-section-chat',
  templateUrl: './section-chat.component.html',
  styleUrl: './section-chat.component.scss'
})
export class SectionChatComponent implements OnInit {
  chats: SectionChat[] = [];
  @Output() chatSelectedEvent = new EventEmitter<Chat | null>();
  constructor(private _messageService: MessageService)
  {

  }
  ngOnInit(): void {
    this._messageService.getSectionChats().subscribe(dataResponse=>
    {
      if(dataResponse.success)
      {
        console.log(dataResponse.data);
        this.chats = dataResponse.data!;
      }
    }
    );
  }

  onChildSelectChat(chat: Chat | null)
  {
    this.chatSelectedEvent.emit(chat);
  }

}
