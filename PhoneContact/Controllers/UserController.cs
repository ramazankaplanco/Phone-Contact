#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PhoneContact.Business;
using PhoneContact.DataAccess.Concrete.DTO;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using PhoneContact.DataAccess.Concrete.DTO.Extension;

#endregion

namespace PhoneContact.Controllers
{
    [System.Web.Mvc.Authorize]
    public class UserController : Controller
    {
        private ApplicationUserManager _userManager;

        public UserController()
        {

        }

        public UserController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get => _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            private set => _userManager = value;
        }

        public ActionResult Index()
        {
            return View();
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
        public async Task<JsonResult> Post([FromBody] User user)
        {
            ResponseBase<User> response;

            try
            {
                var result = await UserManager.CreateAsync(user: user.ToEntity(), user.UserPassword);

                if (!result.Succeeded)
                    throw new ArgumentException(result.Errors.ToString());

                response = new ResponseBase<User>(user);
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
        public async Task<JsonResult> Put(int id, [FromBody] User user)
        {
            ResponseBase<bool> response;

            try
            {
                var isEmailExist = DatabaseUtil.UnitOfWork.Context.Users.Any(p => p.Id != id && p.Email == user.UserName);

                if (isEmailExist)
                    throw new ArgumentException($"{user.UserName} is exist!");

                var currentUser = await UserManager.FindByIdAsync(id);

                currentUser.UserName = user.UserEmail;
                currentUser.Email = user.UserEmail;
                currentUser.FirstName = user.UserFirstName;
                currentUser.LastName = user.UserLastName;
                currentUser.PhoneNumber = user.UserPhoneNumber;
                currentUser.Note = user.UserNote;
                currentUser.PasswordHash = UserManager.PasswordHasher.HashPassword(user.UserPassword);

                var result = await UserManager.UpdateAsync(currentUser);

                if (!result.Succeeded)
                    throw new ArgumentException(result.Errors.ToString());

                response = new ResponseBase<bool>(result.Succeeded);
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