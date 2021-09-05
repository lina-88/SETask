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
    public class CourseController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly DemoContext _context;

        public List<Course> _courses { get; set; }

        public CourseController(IMapper mapper, DemoContext context)
        {

            this._mapper = mapper;
            this._context = context;
        }
        // GET: api/<CourseController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var courses = await _context.Courses
                    //.Include(st => st.StudentCourses)
                    //.ThenInclude(stco => stco.Student)
                    .ToListAsync();
                return Ok(_mapper.Map<List<CourseDto>>(courses));


            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "an error happened" });
            }

        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var localCourse = await _context.Courses.SingleOrDefaultAsync(course => course.Id == id);
                if (localCourse == null) return NotFound(new { Error = "not found" });
                var coursedto = _mapper.Map<CourseDto>(localCourse);
                return Ok(coursedto);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "internal error" });
            }
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<CourseDto>(course));
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Course course)
        {
            try
            {
                var localcourse = await _context.Courses.SingleOrDefaultAsync(co => co.Id == id);
                _context.Remove(localcourse);
                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();

                var coursesDto = _mapper.Map<CourseDto>(course);
                return Ok(coursesDto);

            }
            catch (Exception)
            {
                return StatusCode(400, new { Error = " internal error"});
            }
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var courses = await _context.Courses.SingleOrDefaultAsync(co => co.Id == id);
                _context.Remove(courses);
                await _context.SaveChangesAsync();

                var coursesDto = _mapper.Map<CourseDto>(courses);
                return Ok(coursesDto);

            }
            catch (Exception)
            {
                return StatusCode(404, new { Error = " error intyernal" });
            }
        }
    }
}
