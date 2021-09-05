import { StudentCourseModel } from "./StudentCourse.model";

export interface StudentModel{
    
    name:string;
    gpa:number;
    courses:StudentCourseModel|null
}