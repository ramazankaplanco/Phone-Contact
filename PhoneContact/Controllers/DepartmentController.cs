#region

using System;
using System.Collections.Generic;
using System.Linq;
using PhoneContact.Business;
using PhoneContact.DataAccess.Concrete.DTO;
using System.Web.Http;
using System.Web.Mvc;

#endregion

namespace PhoneContact.Controllers
{
    [System.Web.Mvc.Authorize]
    public class DepartmentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult Get()
        {
            ResponseBase<List<Department>> response;

            try
            {
                response = DatabaseUtil.DepartmentService.GetList();
            }
            catch (Exception e)
            {
                response = new ResponseBase<List<Department>>(null)
                {
                    Message = e.ToString(),
                    Success = false
                };
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult GetById(int id)
        {
            ResponseBase<Department> response;

            try
            {
                response = DatabaseUtil.DepartmentService.GetById(id);
            }
            catch (Exception e)
            {
                response = new ResponseBase<Department>(null)
                {
                    Message = e.Message,
                    Success = false
                };
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Post([FromBody] Department department)
        {
            ResponseBase<Department> response;

            try
            {
                response = DatabaseUtil.DepartmentService.Add(department);
            }
            catch (Exception e)
            {
                response = new ResponseBase<Department>(null)
                {
                    Message = e.Message,
                    Success = false
                };
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpPut]
        //[ValidateAntiForgeryToken]
        public JsonResult Put(int id, [FromBody] Department department)
        {
            ResponseBase<bool> response;

            try
            {
                response = DatabaseUtil.DepartmentService.UpdateById(id, department);
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

        [System.Web.Mvc.HttpDelete]
        //[ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            ResponseBase<bool> response;

            try
            {
                var hasAnyRelation = DatabaseUtil.UnitOfWork.Context.Employees.Any(p => p.DepartmentId.HasValue && p.DepartmentId == id);

                if (hasAnyRelation)
                    throw new ArgumentException("Has relation to Employees !");

                response = DatabaseUtil.DepartmentService.DeleteById(id);
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