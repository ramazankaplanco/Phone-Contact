#region 

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

            var users = DatabaseUtil.UserService.GetList().Data;

            return View(users);
        }

        [System.Web.Mvc.HttpPost]
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

        [System.Web.Mvc.HttpPost]
        public ActionResult Post([FromBody]User user)
        {
            if (user.Id > 0)
                DatabaseUtil.UserService.UpdateById(user.Id, user);
            else
                DatabaseUtil.UserService.Add(user);

            return RedirectToAction("Index", "User");
        }
    }
}