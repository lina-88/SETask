import { StudentCourseModel } from "./StudentCourse.model";

export interface CourseModel{
    
    name:string;
    StudentCourses:StudentCourseModel|null
    
}