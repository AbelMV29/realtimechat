import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './features/nav/navbar/navbar.component';
import { SearchComponent } from './features/nav/search/search.component';
import { NotificationComponent } from './features/nav/notification/notification.component';
import { AccountComponent } from './features/nav/account/account.component';
import { PersonalComponent } from './features/nav/personal/personal.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { SectionChatComponent } from './features/chat/section-chat/section-chat.component';
import { ChatViewComponent } from './features/views/chat-view/chat-view.component';
import { ChatEspecificComponent } from './features/chat/chat-especific/chat-especific.component';
import { ChatOpenComponent } from './features/chat/chat-open/chat-open.component';
import { MessageFormComponent } from './features/chat/message-form/message-form.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { RegisterComponent } from './features/auth/register/register.component';
import { LoginComponent } from './features/auth/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AuthInterceptor } from './core/interceptors/auth.interceptor';
import { HomeComponent } from './features/views/home/home.component';
import { CookieService } from 'ngx-cookie-service';
import { LoadingComponent } from './features/shared/loading/loading.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SearchComponent,
    NotificationComponent,
    AccountComponent,
    PersonalComponent,
    SectionChatComponent,
    ChatViewComponent,
    ChatEspecificComponent,
    ChatOpenComponent,
    MessageFormComponent,
    RegisterComponent,
    LoginComponent,
    HomeComponent,
    LoadingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule,
    FormsModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true},
    CookieService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
