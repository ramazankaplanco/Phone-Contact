#region

using System;
using System.Collections.Generic;
using System.Linq;
using PhoneContact.Business;
using PhoneContact.DataAccess.Concrete.DTO;
using System.Web.Http;
using System.Web.Mvc;
using AllowAnonymousAttribute = System.Web.Http.AllowAnonymousAttribute;

#endregion

namespace PhoneContact.Controllers
{
    public class PublicUIController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        public JsonResult Get()
        {
            ResponseBase<List<Employee>> response;

            try
            {
                response = DatabaseUtil.EmployeeService.GetList();
            }
            catch (Exception e)
            {
                response = new ResponseBase<List<Employee>>(null)
                {
                    Message = e.ToString(),
                    Success = false
                };
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        [System.Web.Mvc.HttpGet]
        public JsonResult GetById(int id)
        {
            ResponseBase<Employee> response;

            try
            {
                response = DatabaseUtil.EmployeeService.GetById(id);
            }
            catch (Exception e)
            {
                response = new ResponseBase<Employee>(null)
                {
                    Message = e.Message,
                    Success = false
                };
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.Authorize]
        [System.Web.Mvc.HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Post([FromBody] Employee employee)
        {
            ResponseBase<Employee> response;

            try
            {
                if (employee.EmployerId.HasValue && employee.EmployerId.Value == employee.Id)
                    throw new ArgumentException("You are already a Employer!");

                response = DatabaseUtil.EmployeeService.Add(employee);
            }
            catch (Exception e)
            {
                response = new ResponseBase<Employee>(null)
                {
                    Message = e.Message,
                    Success = false
                };
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.Authorize]
        [System.Web.Mvc.HttpPut]
        //[ValidateAntiForgeryToken]
        public JsonResult Put(int id, [FromBody] Employee employee)
        {
            ResponseBase<bool> response;

            try
            {
                response = DatabaseUtil.EmployeeService.UpdateById(id, employee);
            }
            catch (Exception e)
            {
                response = new ResponseBase<bool>(false)
                {
                    Message = e.Message,
                    Success = false
                };
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.Authorize]
        [System.Web.Mvc.HttpDelete]
        //[ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            ResponseBase<bool> response;

            try
            {
                var hasAnyRelation = DatabaseUtil.UnitOfWork.Context.Employees.Any(p => p.EmployerId.HasValue && p.EmployerId == id);

                if (hasAnyRelation)
                    throw new ArgumentException("This person is a employer to other Employees !");

                response = DatabaseUtil.EmployeeService.DeleteById(id);
            }
            catch (Exception e)
            {
                response = new ResponseBase<bool>(false)
                {
                    Message = e.Message,
                    Success = false
                };
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}