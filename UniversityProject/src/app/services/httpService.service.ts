
import { Injectable } from '@angular/core';
import { StudentModel } from '../Models/Student.model';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CourseModel } from '../Models/Course.model';
import { StudentCourseModel } from '../Models/StudentCourse.model';

@Injectable({providedIn: 'root'})
export class HttpService {
    baseUrl='http://localhost:60547'
    constructor(private httpClient:HttpClient) { }
    getStudents(url: string){
        return this.httpClient.get<StudentModel[]>(this.baseUrl + url,{
            observe:'response'
        })
    }
    getStudentById(url: string, id:number) {
      return this.httpClient.get<StudentModel>(this.baseUrl + url+"/"+id,{
        observe:'response'
    })
    }
    AddStudent(url: string, student: StudentModel) {
        return this.httpClient.post<StudentModel>(this.baseUrl + url, student, { observe: 'response' })
      }
    
    UpdateStudent(url: string,id:number, student: StudentModel) {
      return this.httpClient.put<StudentModel>(this.baseUrl + url+"/"+id, student, { observe: 'response' })
      }
    
    deleteStudent(url: string,id:number) {
        return this.httpClient.delete<StudentModel>(this.baseUrl + url+"/"+id, {
          observe: 'response'
        })
    }
      
    getCourses(url: string){
        return this.httpClient.get<CourseModel[]>(this.baseUrl + url,{
            observe:'response'
        })
    }
    getCourseById(url: string, id:number) {
      return this.httpClient.get<CourseModel>(this.baseUrl + url+"/"+id,{
        observe:'response'
    },)
    }
    AddCourse(url: string, course: CourseModel) {
        return this.httpClient.post<CourseModel>(this.baseUrl + url, course, { observe: 'response' })
      }

    UpdateCourset(url: string,id:number, course: CourseModel) {
        return this.httpClient.put(this.baseUrl + url+"/"+id, course, { observe: 'response' })
        }
    
    deleteCourse(url: string,id:number) {
        return this.httpClient.delete(this.baseUrl + url+"/"+id, {
          observe: 'response'
        })
    }
    getStudentCourses(url: string){
        return this.httpClient.get<StudentCourseModel[]>(this.baseUrl + url,{
            observe:'response'
        })
    }
    getStudentCourseById(url: string, id:number) {
      return this.httpClient.get<StudentCourseModel>(this.baseUrl + url+"/"+id,{
        observe:'response'
    },)
    }
    AddStudentCourse(url: string, studentcourse: StudentCourseModel) {
        return this.httpClient.post<StudentCourseModel>(this.baseUrl + url, studentcourse, { observe: 'response' })
      }
    
    UpdateStudentCourse(url: string,id:number, studentcourse: StudentCourseModel) {
      return this.httpClient.put<StudentCourseModel>(this.baseUrl + url+"/"+id, studentcourse, { observe: 'response' })
      }
    
    deleteStudentCourse(url: string,id:number) {
        return this.httpClient.delete<StudentCourseModel>(this.baseUrl + url+"/"+id, {
          observe: 'response'
        })
    }
    
    
    
}

