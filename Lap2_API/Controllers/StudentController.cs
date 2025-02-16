using AutoMapper;
using Lap2_API.Dtos;
using Lap2_API.Models;
using Lap2_API.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lap2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;
        private readonly IMapper map;

        public StudentController(UnitOfWork unitOfWork,IMapper _map)
        {
            this.unitOfWork = unitOfWork;
            map = _map;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Student> students=unitOfWork.studentRepo.GetAll();

           List<ReadStudentDto> dtos=map.Map < List<ReadStudentDto>>(students);

            return Ok(dtos);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Student student =unitOfWork.studentRepo.GetById(id);
          ReadStudentDto dto=  map.Map<ReadStudentDto>(student);
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult Add(AddStudentDto dto)
        {
            if (dto == null) return BadRequest();
           Student sts= map.Map<Student>(dto);
           unitOfWork.studentRepo.Add(sts);
            unitOfWork.Save();
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id ,AddStudentDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            Student sts = map.Map<Student>(dto);
            sts.St_Id = id;
           unitOfWork.studentRepo.Update(sts);
            unitOfWork.Save();

            return Ok(dto);

        }
        [HttpDelete]
        public IActionResult DeleteById(int id) 
        {
            Student sts=unitOfWork.studentRepo.GetById(id);
            if(sts == null) return BadRequest();
            unitOfWork.studentRepo.Delete(id);
            unitOfWork.Save();
            return Ok("Deleted Succes");
        }
    }
}
