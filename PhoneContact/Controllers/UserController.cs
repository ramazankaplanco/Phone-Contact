#region

using System;
using System.Collections.Generic;
using System.Web.Helpers;
using PhoneContact.Business;
using PhoneContact.DataAccess.Concrete.DTO;
using System.Web.Http;
using System.Web.Mvc;

#endregion

namespace PhoneContact.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            var session = Session["User"]?.ToString();

            if (session == null)
                return RedirectToAction("Index", "PublicUI");

            return View();
        }

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string userNickName, string userPassword)
        {
            var user = DatabaseUtil.UserService.GetByNickname(userNickName, userPassword).Data;

            if (user == null)
            {
                Session["User"] = null;

                return RedirectToAction("Index", "PublicUI");
            }

            Session["User"] = userNickName;

            return RedirectToAction("Index", "User");
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult Get()
        {
            ResponseBase<List<User>> response;

            try
            {
                response = DatabaseUtil.UserService.GetList();
            }
            catch (Exception e)
            {
                response = new ResponseBase<List<User>>(null)
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
            ResponseBase<User> response;

            try
            {
                response = DatabaseUtil.UserService.GetById(id);
            }
            catch (Exception e)
            {
                response = new ResponseBase<User>(null)
                {
                    Message = e.Message,
                    Success = false
                };
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Post([FromBody] User user)
        {
            ResponseBase<User> response;

            try
            {
                response = DatabaseUtil.UserService.Add(user);
            }
            catch (Exception e)
            {
                response = new ResponseBase<User>(null)
                {
                    Message = e.Message,
                    Success = false
                };
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpPut]
        //[ValidateAntiForgeryToken]
        public JsonResult Put(int id, [FromBody] User user)
        {
            ResponseBase<bool> response;

            try
            {
                response = DatabaseUtil.UserService.UpdateById(id, user);
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
                response = DatabaseUtil.UserService.DeleteById(id);
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