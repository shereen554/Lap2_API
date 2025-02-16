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
    public class DepartmentController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;
        private readonly IMapper map;

        public DepartmentController(UnitOfWork unitOfWork,IMapper _map)
        {
            this.unitOfWork = unitOfWork;
            map = _map;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            List<Department> list =unitOfWork.DeptRepo.GetAll();
          List<ReadDeparmentDto> dtos=  map.Map<List<ReadDeparmentDto>>(list);
            return Ok(dtos);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            Department dept =unitOfWork.DeptRepo.GetById(id);

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
                unitOfWork.DeptRepo.Add(dept);
                int result = unitOfWork.Save();

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

            unitOfWork.DeptRepo.Update(dept);
            unitOfWork.Save();

            return Ok(dto);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id) 
        { 
             Department dpt=  unitOfWork.DeptRepo.GetById(id);
            if (dpt == null) return NotFound();
            unitOfWork.DeptRepo.Delete(id);
            unitOfWork.Save();
            
            return Ok("Succes");
        }
    }
}
