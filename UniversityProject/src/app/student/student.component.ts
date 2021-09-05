import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Subscription } from 'rxjs';
import { StudentModel } from '../Models/Student.model';
import { HttpService } from '../services/httpService.service';



@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styles: [
  ]
})
export class StudentComponent implements OnInit, OnDestroy {


   @ViewChild('f') form!:NgForm
  constructor(private httpService:HttpService) { }
  
   
    studentmessage="";
    
    StudentSub=new Subscription();

    studentsfromdb: StudentModel[] | null=[];

    PostedStudent:StudentModel={
      
      name: "",
      gpa: 0,
      courses:null
    };

    StudentsButton=false;
    poststudentbutton=false;

  ngOnInit(): void {

  }

  getStudentsdb(){
    this.StudentSub=this.httpService.getStudents('/api/Student').subscribe(res=>{
      this.studentsfromdb=res.body
    })
    
    this.StudentsButton=true;
   }
   inputStudentData(){
   
    this.poststudentbutton=true;
   }
  
   onSubmit(){
     this.PostedStudent.name=this.form.form.value.name;
     this.PostedStudent.gpa=this.form.form.value.gpa;
     console.log(this.PostedStudent);
      this.httpService.AddStudent('/api/Student',this.PostedStudent).subscribe(res=>{
        console.log(res.body)
      });
   
    this.studentmessage="Student added successfully";
     
   }
   resetForm(){
     this.form.reset();
   }
  ngOnDestroy(): void{
    this.StudentSub.unsubscribe();

  }
  

 

}
