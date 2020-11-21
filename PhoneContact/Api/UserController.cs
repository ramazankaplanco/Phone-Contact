#region

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PhoneContact.Business.Abstract;
using PhoneContact.Business.Concrete;
using PhoneContact.DataAccess;
using PhoneContact.DataAccess.Abstract;
using PhoneContact.DataAccess.Concrete.DTO;
using PhoneContact.DataAccess.Repository;

#endregion

namespace PhoneContact.Api
{
    // "api/[controller]"
    [Authorize]
    public class UserController : ApiController
    {
        #region Fields

        private UnitOfWork _unitOfWork;

        private IUserRepository _userRepository;
        private IUserService _userService;

        #endregion

        #region Properties

        public UnitOfWork UnitOfWork => _unitOfWork ?? (_unitOfWork = new UnitOfWork());

        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(UnitOfWork.Context));
        public IUserService UserService => _userService ?? (_userService = new UserService(UserRepository));

        #endregion

        #region Http Methods

        // GET: api/User/1
        [ResponseType(typeof(ResponseBase<User>))]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ResponseBase<User> responseBase;

            try
            {
                responseBase = UserService.GetById(id);
            }
            catch (Exception exception)
            {
                responseBase = new ResponseBase<User>(null)
                {
                    Success = false,
                    Message = exception.ToString()
                };
            }
            return Ok(responseBase);
        }

        // GET: api/User
        [ResponseType(typeof(ResponseBase<IList<User>>))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            ResponseBase<List<User>> responseBase;

            try
            {
                responseBase = UserService.GetList();
            }
            catch (Exception exception)
            {
                responseBase = new ResponseBase<List<User>>(null)
                {
                    Message = exception.ToString(),
                    Success = false
                };
            }
            return Ok(responseBase);
        }

        // POST: api/User
        [ResponseType(typeof(ResponseBase<User>))]
        [HttpPost]
        public IHttpActionResult Post([FromBody] User item)
        {
            ResponseBase<User> responseBase;

            try
            {
                if (item == null)
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "that item doesn't exist anything"));

                responseBase = UserService.Add(item);
            }
            catch (Exception exception)
            {
                responseBase = new ResponseBase<User>(null)
                {
                    Success = false,
                    Message = exception.ToString()
                };
            }
            return Ok(responseBase);
        }

        // PUT: api/User/1
        [ResponseType(typeof(ResponseBase<bool>))]
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] User item)
        {
            ResponseBase<bool> responseBase;

            try
            {
                if (item == null)
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "that item doesn't exist anything"));

                responseBase = UserService.UpdateById(id, item);
            }
            catch (Exception exception)
            {
                responseBase = new ResponseBase<bool>(false)
                {
                    Success = false,
                    Message = exception.ToString()
                };
            }
            return Ok(responseBase);
        }

        // DELETE: api/User/1
        [ResponseType(typeof(ResponseBase<bool>))]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            ResponseBase<bool> responseBase;

            try
            {
                responseBase = UserService.DeleteById(id);
            }
            catch (Exception exception)
            {
                responseBase = new ResponseBase<bool>(false)
                {
                    Success = false,
                    Message = exception.ToString()
                };
            }
            return Ok(responseBase);
        }
        #endregion
    }
}