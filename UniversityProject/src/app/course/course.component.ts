import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';

import { HttpService } from '../services/httpService.service';
import { StudentModel } from '../Models/Student.model';
import { Subscription } from 'rxjs';
import { CourseModel } from '../Models/Course.model';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styles: [
  ]
})
export class CourseComponent implements OnInit,OnDestroy {
  
  @ViewChild('f') form!:NgForm
  constructor(private httpService:HttpService) { }
  coursemessage="";
  CourseSub=new Subscription();
  postcoursebutton=false;
  
  coursesfromdb: CourseModel[] | null=[];
  CoursesButton=false;

  PostedCourse:CourseModel={
    
    name:"",
    StudentCourses:null
  }
  ngOnInit(): void {
    
  }
  getCoursesdb(){
    this.CourseSub==this.httpService.getCourses('/api/Course').subscribe(res=>{
      this.coursesfromdb=res.body
    })
    this.CoursesButton=true;
   }
   inputCourseData(){
   
    this.postcoursebutton=true;
   }
   onSubmit(){
    this.PostedCourse.name=(this.form.form.value.name);
    console.log(this.PostedCourse);
     this.httpService.AddCourse('/api/Course',this.PostedCourse).subscribe(res=>{
      console.log(res.body)
    });
  
    this.coursemessage="Course added successfully";
    
  }

  resetForm(){
    this.form.reset();
  }
  ngOnDestroy(){
    this.CourseSub.unsubscribe();
  }



}
