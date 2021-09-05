import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { StudentCourseModel } from '../Models/StudentCourse.model';
import { HttpService } from '../services/httpService.service';


@Component({
  selector: 'app-student-course',
  templateUrl: './student-course.component.html',
  styles: [
  ]
})
export class StudentCourseComponent implements OnInit {
  @ViewChild('f') form!:NgForm
  constructor( private httpService:HttpService) { }

  stcomessage="";
  StudentCourseSub=new Subscription();
  Studentcoursepostsub=new Subscription();

  PostedStudentCourse:StudentCourseModel={
    
    courseId: 0,
    studentId: 0,
    student: null,
    course: null,
   
  };

  poststudentcoursebutton=false;
    studentcoursesfromdb: StudentCourseModel[] | null=[];
    StudentCoursesButton=false;

  ngOnInit(): void {
    //this.StudentCourseSub=this.interactionservice.StudentCoursesSource.subscribe(StudentCourses=>this.studentcoursesfromdb=StudentCourses);

  }

  getStudentCoursesdb(){
    this.StudentCourseSub=this.httpService.getStudentCourses('/api/StudentCourse').subscribe(res=>{
      this.studentcoursesfromdb=res.body
    })
    this.StudentCoursesButton=true;
    console.log("got them");
   }
   inputStudentCourseData(){
   
    this.poststudentcoursebutton=true;
   }
   onSubmit(){
    
    this.PostedStudentCourse.courseId=this.form.form.value.courseid;
    this.PostedStudentCourse.studentId=this.form.form.value.studentid;
    
    this.Studentcoursepostsub=this.httpService.AddStudentCourse('/api/StudentCourse',this.PostedStudentCourse).subscribe(res=>{
      console.log(res.body)
    });
    this.stcomessage="Subsicription addedd successfully";
    
    
   }
   resetForm(){
    this.form.reset();
  }

  ngOnDestroy(): void{
    this.StudentCourseSub.unsubscribe();
    this.Studentcoursepostsub.unsubscribe();


  }
  

 


}
