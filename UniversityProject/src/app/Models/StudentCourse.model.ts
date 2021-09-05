import { CourseModel } from "./Course.model";
import { StudentModel } from "./Student.model";


export interface StudentCourseModel{
    
    courseId:number;
    studentId:number;
    student:StudentModel|null;
    course:CourseModel|null
  
}