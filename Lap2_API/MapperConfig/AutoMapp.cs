using AutoMapper;
using Lap2_API.Dtos;
using Lap2_API.Models;

namespace Lap2_API.MapperConfig
{
    public class AutoMapp:Profile
    {
        public AutoMapp()
        {

            CreateMap<Department, ReadDeparmentDto>().AfterMap((src, des) =>
            {
                des.Id=src.Dept_Id;
                des.Name=src.Dept_Name;
                if(src.Dept_Manager !=null)
                des.Manager=src.Dept_ManagerNavigation.Ins_Name;
                des.Manager_hiredate=src.Manager_hiredate;
                des.Description = src.Dept_Desc;
                des.Location = src.Dept_Location; 
                des.NumberOfStudent=src.Students?.Count() ?? 0;

            }).ReverseMap();

            CreateMap<AddDepartmentDto, Department>().AfterMap((src, des) =>
            {
                
                des.Dept_Name = src.Name;
                if (src.ManagerId != null)
                des.Dept_Manager = src.ManagerId;
                des.Manager_hiredate = src.Manager_hiredate;
                des.Dept_Desc = src.Description;
                des.Dept_Location = src.Location;
            }).ReverseMap();

            CreateMap<Student, ReadStudentDto>().AfterMap((src,des) =>
            {
                des.Department = src.Dept.Dept_Name;
                des.SuperVisor = src.St_superNavigation?.St_Fname.ToString() +" " + src.St_superNavigation?.St_Lname.ToString();

            }).ReverseMap();


            CreateMap<AddStudentDto,Student>().AfterMap((src,des) => 
            {
                des.Dept_Id = src.DepartMentId;
                des.St_super=src.SupervisorId;
            }).ReverseMap();
        }

    }
}

