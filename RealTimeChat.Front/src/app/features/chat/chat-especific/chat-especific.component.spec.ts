import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChatEspecificComponent } from './chat-especific.component';

describe('ChatEspecificComponent', () => {
  let component: ChatEspecificComponent;
  let fixture: ComponentFixture<ChatEspecificComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ChatEspecificComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ChatEspecificComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
