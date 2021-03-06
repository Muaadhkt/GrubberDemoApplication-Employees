using GrubberDemo.Models;
using GrubberDemo.Models.EFEntities;
using GrubberDemo.Models.EFEntities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrubberDemo.Services
{
    public class EmployeeService
    {
        GrubberDBContext _context = new GrubberDBContext();


        //Get employee by id
        public EmployeeViewModel GetEmployeeById(int? id)
        {
            try
            {
                var employee = _context.Employee.Where(e => e.PkEmployeeId == id && e.RowStatus == 1).FirstOrDefault();
                if (employee == null) return new EmployeeViewModel
                {
                    GenderList = new List<SelectListItem> {
                        new SelectListItem { Text="Male", Value="1" },
                        new SelectListItem { Text="Female", Value="2"}
                    },
                    SkillsList = this.GetSkills(),
                    HobbiesList = this.GetHobbies()
                };
                var result = new EmployeeViewModel
                {
                    PkEmployeeId = employee.PkEmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Address = employee.Address,
                    About = employee.About,
                    JoinDate = employee.JoinDate,
                    BirthDate = employee.BirthDate,
                    GenderList = new List<SelectListItem> {
                        new SelectListItem { Text="Male", Value="1", Selected=employee.Gender.Equals("1") ? true: false},
                        new SelectListItem { Text="Female", Value="2", Selected=employee.Gender.Equals("1") ? true: false}
                    },
                    Role = employee.Role,
                    SkillsList = this.GetSkills(),
                    HobbiesList = this.GetHobbies()
                };
                return result;
            }
            catch (Exception ex)
            {
                return new EmployeeViewModel();
            }
        }

        //Get hobbies list
        public List<SelectListItem> GetHobbies()
        {
            return new List<SelectListItem> {
                        new SelectListItem { Text="Playin cricket", Value="1", Selected=true},
                        new SelectListItem { Text="Dot Net", Value="2"},
                        new SelectListItem { Text="Android", Value="3"},
                        new SelectListItem { Text="iOS", Value="4",Selected=true},
                        new SelectListItem { Text="Java", Value="5"},
                        new SelectListItem { Text="SQL", Value="6"}
                    };
        }

        //get skills list
        public List<SelectListItem> GetSkills()
        {
            return new List<SelectListItem> {
                        new SelectListItem { Text="HTML/CSS", Value="1", Selected=true},
                        new SelectListItem { Text="Dot Net", Value="2"},
                        new SelectListItem { Text="Android", Value="3"},
                        new SelectListItem { Text="iOS", Value="4"},
                        new SelectListItem { Text="Java", Value="5",Selected=true},
                        new SelectListItem { Text="SQL", Value="6"}
                    };
        }

        /// <summary>
        /// To add/edit the employees
        /// </summary>
        /// <param name="employeeViewModel">Employee view model</param>
        /// <returns>Result Status</returns>
        public int AddEditEmployees(EmployeeViewModel employeeViewModel)
        {
            try
            {
                if (employeeViewModel.PkEmployeeId > 0)
                {
                    return this.UpdateEmployees(employeeViewModel);
                }

                var employee = new Employee
                {
                    FirstName = employeeViewModel.FirstName,
                    LastName = employeeViewModel.LastName,
                    Address = employeeViewModel.Address,
                    About = employeeViewModel.About,
                    BirthDate = employeeViewModel.BirthDate,
                    JoinDate = employeeViewModel.JoinDate,
                    Gender = employeeViewModel.Gender,
                    Role = employeeViewModel.Role,
                    Skills = employeeViewModel.Skills,
                    Hobbies = employeeViewModel.Hobbies,
                    RowStatus = 1 // active row
                };
                _context.Employee.Add(employee);
                _context.SaveChanges();
                return 1;// Success
            }
            catch (Exception ex)
            {
                return 0;// Failed
            }
        }

        //Update the employee
        private int UpdateEmployees(EmployeeViewModel employeeViewModel)
        {
            try
            {
                var employee = _context.Employee
                    .Where(e => e.PkEmployeeId == employeeViewModel.PkEmployeeId).FirstOrDefault();

                employee.FirstName = employeeViewModel.FirstName;
                employee.LastName = employeeViewModel.LastName;
                employee.Address = employeeViewModel.Address;
                employee.About = employeeViewModel.About;
                employee.BirthDate = employeeViewModel.BirthDate;
                employee.JoinDate = employeeViewModel.JoinDate;
                employee.Gender = employeeViewModel.Gender;
                employee.Role = employeeViewModel.Role;
                employee.Skills = employeeViewModel.Skills;
                employee.Hobbies = employeeViewModel.Hobbies;
                _context.SaveChanges();
                return 1;// Success
            }
            catch (Exception ex)
            {
                return 0;// Failed
            }
        }

        /// <summary>
        /// To get all the employees
        /// </summary>
        /// <param name="id">Page number id</param>
        /// <returns>List of employees</returns>
        public List<EmployeeViewModel> GetAllEmployees(int? id)
        {
            try
            {
                var employees = _context.Employee.Where(e => e.RowStatus == 1)
                    .Select(res => new EmployeeViewModel
                    {
                        PkEmployeeId = res.PkEmployeeId,
                        FirstName = res.FirstName,
                        LastName = res.LastName,
                        Address = res.Address,
                        About = res.About,
                        Gender = res.Gender,
                        BirthDate = res.BirthDate,
                        JoinDate = res.JoinDate,
                        Hobbies = res.Hobbies,
                        Skills = res.Skills,
                        Role = res.Role
                    }).ToList();
                return employees;
            }
            catch (Exception ex)
            {
                return new List<EmployeeViewModel>();
            }
        }
        /// <summary>
        /// To delete the employees
        /// </summary>
        /// <param name="id">employee id</param>
        /// <returns>Result staus</returns>
        public int DeleteEmployee(int id)
        {
            try
            {
                var employees = _context.Employee.Where(e => e.PkEmployeeId == id
                                        && e.RowStatus == 1).FirstOrDefault();

                if (employees != null)
                {
                    employees.RowStatus = 0;
                    _context.SaveChanges();
                }

                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}