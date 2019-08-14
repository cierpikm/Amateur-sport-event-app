import { MessageService } from './shared/message.service';
import { EventService } from './shared/event.service';
import { AchievementService } from './shared/achievement.service';
import { AdvertisementService } from './shared/advertisement.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { UserService } from './shared/user.service';
import { ReactiveFormsModule } from '@angular/forms';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { SideNavbarComponent } from './side-navbar/side-navbar.component';
import { AdvertisementComponent } from './advertisement-group/advertisement/advertisement.component';
import { AchievementComponent } from './achievement-group/achievement/achievement.component';
import { SettingComponent } from './setting/setting.component';
import { OwnAdvertisementComponent } from './advertisement-group/own-advertisement/own-advertisement.component';
import { AllAdvertisementComponent } from './advertisement-group/all-advertisement/all-advertisement.component';
import { AddAdvertisementComponent } from './advertisement-group/add-advertisement/add-advertisement.component';
import { UserComponent } from './user/user.component';
import { MessageComponent } from './message/message.component';
import { EventsComponent } from './events-group/events/events.component';
import { AcceptedAdvertisementComponent } from './advertisement-group/accepted-advertisement/accepted-advertisement.component';
import { UsersComponent } from './users/users.component';
import { GalleryComponent } from './users/gallery/gallery.component';
import { UsersDataComponent } from './users/users-data/users-data.component';
import { OwnAchievementComponent } from './achievement-group/own-achievement/own-achievement.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatBadgeModule } from '@angular/material/badge';
import { MatNativeDateModule } from '@angular/material/core';
import { AddEventsComponent } from './events-group/add-events/add-events.component';
import {ScrollingModule} from '@angular/cdk/scrolling';
import { MatInputModule } from '@angular/material/input';
import { LOCALE_ID } from '@angular/core';
import {MatDialogModule} from '@angular/material/dialog';
import {MatIconModule} from '@angular/material/icon';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { registerLocaleData } from '@angular/common';
import localePl from '@angular/common/locales/pl';
import { ChatComponent } from './message/chat/chat.component';
import { OwlDateTimeModule, OwlNativeDateTimeModule } from 'ng-pick-datetime';

registerLocaleData(localePl, 'pl');

@NgModule({
  exports: [
    MatSnackBarModule,
    MatBadgeModule,
    MatNativeDateModule,
    MatInputModule,
    ScrollingModule,
  ],
  declarations: [

    AppComponent,
    HomeComponent,
    RegisterComponent,
    LoginComponent,
    UserProfileComponent,
    SideNavbarComponent,
    AdvertisementComponent,
    AchievementComponent,
    OwnAchievementComponent,
    SettingComponent,
    OwnAdvertisementComponent,
    AllAdvertisementComponent,
    AddAdvertisementComponent,
    UserComponent,
    MessageComponent,
    EventsComponent,
    AcceptedAdvertisementComponent,
    UsersComponent,
    GalleryComponent,
    UsersDataComponent,
    AddEventsComponent,
    ChatComponent
  ],
  imports: [
    MatBadgeModule,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    MDBBootstrapModule.forRoot(),
    BrowserAnimationsModule,
    NgbModule,
    MatInputModule,
    ScrollingModule,
    OwlDateTimeModule,
    OwlNativeDateTimeModule,
    MatDialogModule,
    MatIconModule
  ],
  providers: [
    UserService,
    AdvertisementService,
    AchievementService,
    EventService,
    MessageService,
    {provide: LOCALE_ID, useValue: 'pl-PL'}
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
