using aspPractise.Data;
using aspPractise.Help.Dto;
using aspPractise.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace aspPractise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly DemoContext _context;

        


        public StudentCourseController(IMapper mapper, DemoContext context)
        {

            this._mapper = mapper;
            this._context = context;
        }
        // GET: api/<StudentCourseController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var studentcourses = await _context.StudentCourses
                    
                    .ToListAsync();
                return Ok(_mapper.Map<List<StudentCourseDto>>(studentcourses));






            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "an error happened" });
            }

        }

        // GET api/<StudentCourseController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var localStudentCourse = await _context.StudentCourses.SingleOrDefaultAsync(st => st.Id == id);
                if (localStudentCourse == null) return NotFound(new { Error = "not found" });
                var studentcoursedto = _mapper.Map<StudentCourseDto>(localStudentCourse);
                return Ok(studentcoursedto);
                
            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "internal error" });
            }
        }

        // POST api/<StudentCourseController>
        [HttpPost]
        public async Task<IActionResult>  Post([FromBody] StudentCourse studentcourse)
        {
            await _context.StudentCourses.AddAsync(studentcourse);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<StudentCourseDto>(studentcourse));
        }

        // PUT api/<StudentCourseController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] StudentCourse studentCourse)
        {
            try
            {
                var LocalstudentCourse = await _context.StudentCourses.SingleOrDefaultAsync(sc => sc.Id == id);
                _context.Remove(LocalstudentCourse);
                await _context.StudentCourses.AddAsync(studentCourse);
                await _context.SaveChangesAsync();

                var studentCourseDto = _mapper.Map<StudentCourseDto>(studentCourse);
                return Ok(studentCourseDto);

            }
            catch (Exception)
            {
                return StatusCode(400, new { Error = " error intyernal" });
            }
        }

        // DELETE api/<StudentCourseController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
                try
                {
                    var studentCourse = await _context.StudentCourses.SingleOrDefaultAsync(sc => sc.Id == id);
                    _context.Remove(studentCourse);
                    await _context.SaveChangesAsync();


                    var studentCourseDto = _mapper.Map<StudentCourseDto>(studentCourse);
                    return Ok(studentCourseDto);

                }
                catch (Exception)
                {
                    return StatusCode(404, new { Error = "internal error" });
                }

            }
        }
    }

