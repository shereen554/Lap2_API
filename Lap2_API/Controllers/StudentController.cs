using AutoMapper;
using Lap2_API.Dtos;
using Lap2_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lap2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ITIContext db;
        private readonly IMapper map;

        public StudentController(ITIContext db,IMapper _map)
        {
            this.db = db;
            map = _map;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Student> students=db.Students.ToList();

           List<ReadStudentDto> dtos=map.Map < List<ReadStudentDto>>(students);

            return Ok(dtos);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Student student =db.Students.FirstOrDefault(n=>n.St_Id==id);
          ReadStudentDto dto=  map.Map<ReadStudentDto>(student);
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Add(AddStudentDto dto)
        {
            if (dto == null) return BadRequest();
           Student sts= map.Map<Student>(dto);
            db.Students.Add(sts);
            db.SaveChanges();
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id ,AddStudentDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            Student sts = map.Map<Student>(dto);
            sts.St_Id = id;
            db.Entry(sts).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return Ok(dto);

        }
        [HttpDelete]
        public IActionResult DeleteById(int id) 
        {
            Student sts=db.Students.FirstOrDefault(n=>n.St_Id == id);
            if(sts == null) return BadRequest();
            db.Students.Remove(sts);
            db.SaveChanges();
            return Ok("Deleted Succes");
        }
    }
}
