import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChatOpenComponent } from './chat-open.component';

describe('ChatOpenComponent', () => {
  let component: ChatOpenComponent;
  let fixture: ComponentFixture<ChatOpenComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ChatOpenComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ChatOpenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
