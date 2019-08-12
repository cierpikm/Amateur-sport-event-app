import { AddEventsComponent } from './events-group/add-events/add-events.component';
import { UsersComponent } from './users/users.component';
import { AcceptedAdvertisementComponent } from './advertisement-group/accepted-advertisement/accepted-advertisement.component';
import { EventsComponent } from './events-group/events/events.component';
import { MessageComponent } from './message/message.component';
import { AddAdvertisementComponent } from './advertisement-group/add-advertisement/add-advertisement.component';
import { OwnAdvertisementComponent } from './advertisement-group/own-advertisement/own-advertisement.component';
import { AllAdvertisementComponent } from './advertisement-group/all-advertisement/all-advertisement.component';
import { SettingComponent } from './setting/setting.component';
import { AchievementComponent } from './achievement-group/achievement/achievement.component';
import { SideNavbarComponent } from './side-navbar/side-navbar.component';
import { AuthGuard } from './auth/auth.guard';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { OwnAchievementComponent } from './achievement-group/own-achievement/own-achievement.component';


const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'register', component: RegisterComponent},
  {path: 'login', component: LoginComponent},
  {path: 'user', component: UserComponent, canActivate: [AuthGuard], children: [
    {path: 'allAdvertisement', component: AllAdvertisementComponent, canActivate: [AuthGuard]},
    {path: 'ownAdvertisement', component: OwnAdvertisementComponent, canActivate: [AuthGuard]},
    {path: 'addAdvertisement', component: AddAdvertisementComponent, canActivate: [AuthGuard]},
    {path: 'acceptedAdvertisement', component: AcceptedAdvertisementComponent, canActivate: [AuthGuard]},
    {path: 'profile', component: UserProfileComponent, canActivate: [AuthGuard]},
    {path: 'ownAchievement', component: OwnAchievementComponent, canActivate: [AuthGuard]},
    {path: 'achievement', component: AchievementComponent, canActivate: [AuthGuard]},
    {path: 'setting', component: SettingComponent, canActivate: [AuthGuard]},
    {path: 'message', component: MessageComponent, canActivate: [AuthGuard]},
    {path: 'events', component: EventsComponent, canActivate: [AuthGuard]},
    {path: 'addEvent', component: AddEventsComponent, canActivate: [AuthGuard]},
    {path: 'users/:userName', component: UsersComponent, canActivate: [AuthGuard]},

  ]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
