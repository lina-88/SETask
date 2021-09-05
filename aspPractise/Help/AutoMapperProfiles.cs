using aspPractise.Help.Dto;
using aspPractise.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspPractise.Help
{
    public class AutoMapperProfiles : Profile
    {
          public AutoMapperProfiles()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            //.ForMember(dest => dest.summary, opt => opt.MapFrom(src => src.Name +" "+ src.Gpa));

            CreateMap<Course, CourseDto>().ReverseMap();

            CreateMap<StudentCourse, StudentCourseDto>().ReverseMap();

           

        }





    }
}
