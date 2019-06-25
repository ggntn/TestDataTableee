using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTable.Models.db;
using DataTable.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace DataTable.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDBContext db = new EmployeeDBContext();
        public ActionResult Index()
        {
            var model = new DataTable.ViewModel.TestViewModel();
            model.GenderList = db.Gender.Where(w => w.IsEnable).ToList();
            model.AgeList = new List<SelectListItem>()
                                {
                                new SelectListItem{ Text="Select Age", Value = "0" },
                                new SelectListItem{ Text="15", Value = "15" },
                                new SelectListItem{ Text="16", Value = "16" },
                                new SelectListItem{ Text="17", Value = "17" },
                                new SelectListItem{ Text="18", Value = "18" },
                                new SelectListItem{ Text="19", Value = "19" },
                                new SelectListItem{ Text="20", Value = "20" },
                                new SelectListItem{ Text="21", Value = "21" },
                                new SelectListItem{ Text="22", Value = "22" },
                                new SelectListItem{ Text="23", Value = "23" },
                                new SelectListItem{ Text="24", Value = "24" },
                                new SelectListItem{ Text="25", Value = "25" },
                                new SelectListItem{ Text="26", Value = "26" },
                                new SelectListItem{ Text="27", Value = "27" },
                                new SelectListItem{ Text="28", Value = "28" },
                                new SelectListItem{ Text="29", Value = "29" },
                                new SelectListItem{ Text="30", Value = "30" },
                                new SelectListItem{ Text="31", Value = "31" },
                                new SelectListItem{ Text="32", Value = "32" },
                                new SelectListItem{ Text="33", Value = "33" },
                                new SelectListItem{ Text="34", Value = "34" },
                                new SelectListItem{ Text="35", Value = "35" },
                                };
            return View(model);
        }

        public JsonResult GetList(string searchbox)
        {
            var t = searchbox;
            try
            {
                var emplist = (from em in db.Employee
                               join gen in db.Gender on em.GenderId equals gen.GenderId
                               select new TestViewModel
                               {
                                   EmployeeId = em.EmployeeId,
                                   Name = em.Name,
                                   Position = em.Position,
                                   Office = em.Office,
                                   Age = em.Age,
                                   Salary = em.Salary,
                                   Sex = em.Sex,
                                    dtmDate=em.Date,
                                   NameGen = gen.Name,
                                   IsEnable = gen.IsEnable,
                                   GenderId = gen.GenderId,
                                  
                               }).ToList();

                if (string.IsNullOrEmpty(searchbox))
                {
                    return Json(new { data = emplist });
                }
                else
                {
                    emplist = emplist.Where(w => w.Name.Contains(searchbox) || w.Office.Contains(searchbox)).ToList();
                    return Json(new { data = emplist });
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                return Json(null);
            }
        }

        public JsonResult GetEmployeeById(int EmployeeId)
        {
            var model = (from em in db.Employee
                         join gen in db.Gender on em.GenderId equals gen.GenderId
                         where em.EmployeeId == EmployeeId
                         select new TestViewModel
                         {
                             EmployeeId = em.EmployeeId,
                             Name = em.Name,
                             Position = em.Position,
                             Office = em.Office,
                             Age = em.Age,
                             Salary = em.Salary,
                             Sex = em.Sex,
                             NameGen = gen.Name,
                             IsEnable = gen.IsEnable,
                             GenderId = gen.GenderId,
                             //dtmDate = em.Date

                         }).FirstOrDefault();
            return Json(model);
        }

        public JsonResult SaveEmployeeId(TestViewModel emp)
        {
            var result = false;

            try
            {
                //if (ModelState.IsValid)
                //{
                if (emp.EmployeeId > 0)
                {
                    Employee Emp = db.Employee.SingleOrDefault(x => x.EmployeeId == emp.EmployeeId);
                    Emp.Name = emp.Name;
                    Emp.Position = emp.Position;
                    Emp.Office = emp.Office;
                    Emp.Age = emp.Age;
                    Emp.Salary = emp.Salary;
                    if (emp.Sex == "male")
                    {
                        Emp.Sex = "male";
                    }
                    else
                        Emp.Sex = "female";
                    
                    if(emp.GenderId == 1)
                    {
                        Emp.GenderId = 1;
                    }else if (emp.GenderId == 2)
                    {
                        Emp.GenderId = 2;
                    }
                    else
                        Emp.GenderId = 3;
                    Emp.Date = emp.dtmDate;
                    db.SaveChanges();
                    result = true;
                }
                else
                {
                    Employee Emp = new Employee();
                    Emp.Name = emp.Name;
                    Emp.Position = emp.Position;
                    Emp.Office = emp.Office;
                    Emp.Age = emp.Age;
                    Emp.Salary = emp.Salary;

                    if (emp.Sex == "male")
                    {
                        Emp.Sex = "male";
                    }
                    else
                        Emp.Sex = "female";

                    if (emp.GenderId == 1)
                    {
                        Emp.GenderId = 1;
                    }
                    else if (emp.GenderId == 2)
                    {
                        Emp.GenderId = 2;
                    }
                    else
                        Emp.GenderId = 3;
                    Emp.Date = emp.dtmDate;
                    db.Employee.Add(Emp);
                    db.SaveChanges();
                    result = true;

                }
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(result);
        }
        public JsonResult DeleteId(int EmployeeId)
        {
            var test = EmployeeId;
            bool result = false;

            Employee emp = db.Employee.SingleOrDefault(x => x.EmployeeId == EmployeeId);
            if (emp != null)
            {
                db.Employee.Remove(emp);
                db.SaveChanges();
                result = true;
            }
            return Json(result);

        }
       


    }
}