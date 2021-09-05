import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { StudentComponent } from './student/student.component';
import { CourseComponent } from './course/course.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { StudentCourseComponent } from './student-course/student-course.component';
import { WelcomeComponent } from './welcome/welcome.component';
import { HttpClientModule } from '@angular/common/http';
@NgModule({
  declarations: [
    AppComponent,
    StudentComponent,
    CourseComponent,
    NavBarComponent,
    StudentCourseComponent,
    WelcomeComponent,
   
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
