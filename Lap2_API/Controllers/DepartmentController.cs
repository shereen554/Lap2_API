using AutoMapper;
using Lap2_API.Dtos;
using Lap2_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lap2_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ITIContext db;
        private readonly IMapper map;

        public DepartmentController(ITIContext db,IMapper _map)
        {
            this.db = db;
            map = _map;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            List<Department> list = db.Departments.ToList();
          List<ReadDeparmentDto> dtos=  map.Map<List<ReadDeparmentDto>>(list);
            return Ok(dtos);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            Department dept =db.Departments.FirstOrDefault(n=>n.Dept_Id == id);

           ReadDeparmentDto dto= map.Map<ReadDeparmentDto>(dept);
            return Ok(dto);
        }

        [HttpPost]
        public IActionResult AddDepartment(AddDepartmentDto dto) 
        {
            try
            {
                if (dto == null || string.IsNullOrEmpty(dto.Name))
                    return BadRequest("Invalid input data.");

                Department dept = map.Map<Department>(dto);
                db.Departments.Add(dept);
                int result = db.SaveChanges();

                if (result > 0)
                    return Ok(dept);
                else
                    return BadRequest("No changes were made to the database.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error saving data: {ex.Message}");
            }

        }
        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(int id,AddDepartmentDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            Department dept = map.Map<Department>(dto);
            dept.Dept_Id= id;

                db.Entry(dept).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

            return Ok(dto);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id) 
        { 
            Department dpt =db.Departments.FirstOrDefault(n=>n.Dept_Id==id);
            if (dpt == null) return NotFound();
            db.Departments.Remove(dpt);
            db.SaveChanges();
            
            return Ok("Succes");
        }
    }
}
