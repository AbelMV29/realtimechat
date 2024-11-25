import { Component, ElementRef, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { faImage, faShare } from '@fortawesome/free-solid-svg-icons';
import { MessageSend } from '../../../core/form/message-send';
import { MessageService } from '../../../core/services/message.service';
import { Message } from '../../../core/models/message';

@Component({
  selector: 'app-message-form',
  templateUrl: './message-form.component.html',
  styleUrl: './message-form.component.scss'
})
export class MessageFormComponent {
  faImage = faImage;
  faShare = faShare;
  messageForm: FormGroup;
  @Input() receiverId!:number;
  @Output() messageEvent = new EventEmitter<Message>();
  @ViewChild("fileInput") fileInput!: ElementRef;

  constructor(private _formBuilder: FormBuilder, private _messageService: MessageService)
  {
    this.messageForm = _formBuilder.group({
      body: ['', Validators.required],
      mediaUrl: ['']
    })
  }

  sendMessage()
  {
    if(this.messageForm.valid)
    {
      let messageToSend : MessageSend = this.messageForm.value;
      messageToSend.receiverId = this.receiverId;

      const formData = new FormData();
      formData.append('body', messageToSend.body);
      formData.append("receiverId", messageToSend.receiverId.toString());
      if(messageToSend.mediaUrl)
      {
        formData.append('mediaUrl', messageToSend.mediaUrl);
      }
      
      this._messageService.sendMessage(formData).subscribe(dataResponse=>
      {
        if(dataResponse.success)
        {
          this.messageEvent.emit(dataResponse.data!);
          this.fileInput.nativeElement.value = "";
        }
        else
        {
          console.log(dataResponse.errorMessage);
        }
      });
    }
  }
}
