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
    public class StudentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DemoContext _context;

        //public List<Student> _students { get; set; }

       
        public StudentController(IMapper mapper, DemoContext context)
        {
           
            this._mapper = mapper;
            this._context = context;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var students = await _context.Students
                    //.Include(st => st.Courses)
                    //.ThenInclude(stco => stco.Course)
                    .ToListAsync();
                return Ok(_mapper.Map<List<StudentDto>>(students));


            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "an error happened" });
            }
            
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var localStudent = await _context.Students.SingleOrDefaultAsync(st => st.Id == id);
                if (localStudent == null) return NotFound(new { Error = "not found" });
                var studentDto = _mapper.Map<StudentDto>(localStudent);
                return Ok(studentDto);
             }
            catch(Exception)
            {
                return StatusCode(500, new { Error = "internal error" });
            }
        }

        // POST api/<StudentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student student)
        {
            try
            {

              

                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
                var studentDto= _mapper.Map<StudentDto>(student);
                return Ok(studentDto);

               


            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "internal error" });
            }


        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Student student)
        {
            try
            {
                //validate student, if not valid return badrequest

                var localStudent = await _context.Students.SingleOrDefaultAsync(st => st.Id == id);
                if (localStudent == null) return NotFound(new { Error = "not found" });
                _context.Remove(localStudent);
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
                var studentDto = _mapper.Map<StudentDto>(student);
                return Ok(studentDto);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "internal error" });

            }
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var localStudent = await _context.Students.SingleOrDefaultAsync(st => st.Id == id);
                if (localStudent == null) return NotFound(new { Error = "not found" });
                _context.Remove(localStudent);
                await _context.SaveChangesAsync();
                var studentDto = _mapper.Map<StudentDto>(localStudent);
                return Ok(studentDto);
            }
            catch (Exception)
            {
                return StatusCode(500, new { Error = "internal error" });

            }
        }
    }
}
