import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChatViewComponent } from './features/views/chat-view/chat-view.component';
import { RegisterComponent } from './features/auth/register/register.component';
import { LoginComponent } from './features/auth/login/login.component';
import { HomeComponent } from './features/views/home/home.component';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'chat', component: ChatViewComponent, canActivate: [AuthGuard]},
  {path: 'register', component: RegisterComponent},
  {path: 'login', component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
