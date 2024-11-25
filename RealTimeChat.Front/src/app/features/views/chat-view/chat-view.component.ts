import { Component } from '@angular/core';
import { Chat } from '../../../core/models/chat';

@Component({
  selector: 'app-chat-view',
  templateUrl: './chat-view.component.html',
  styleUrl: './chat-view.component.scss'
})
export class ChatViewComponent {
  chatSelected: Chat | null = null;
  onChatSelected(chat: Chat | null) {
    this.chatSelected = chat;
  }
}
