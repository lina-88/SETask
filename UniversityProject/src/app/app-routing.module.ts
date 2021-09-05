import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CourseComponent } from './course/course.component';
import { StudentCourseComponent } from './student-course/student-course.component';
import { StudentComponent } from './student/student.component';
import { WelcomeComponent } from './welcome/welcome.component';

const routes: Routes = [
  {path:'',component:WelcomeComponent},
  {path:'Students',component:StudentComponent},
  {path:'Courses',component:CourseComponent},
  {path:'StudentCourses',component:StudentCourseComponent},
  {path:'**',redirectTo:'/',pathMatch:"full"},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
