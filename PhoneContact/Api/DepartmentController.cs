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
    public class DepartmentController : ApiController
    {
        #region Fields

        private UnitOfWork _unitOfWork;

        private IDepartmentRepository _departmentRepository;
        private IDepartmentService _departmentService;

        #endregion

        #region Properties

        public UnitOfWork UnitOfWork => _unitOfWork ?? (_unitOfWork = new UnitOfWork());

        public IDepartmentRepository DepartmentRepository => _departmentRepository = _departmentRepository ?? new DepartmentRepository(UnitOfWork.Context);
        public IDepartmentService DepartmentService => _departmentService = _departmentService ?? new DepartmentService(DepartmentRepository);

        #endregion

        #region Http Methods

        // GET: api/Department/1
        [ResponseType(typeof(ResponseBase<Department>))]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ResponseBase<Department> responseBase;

            try
            {
                responseBase = DepartmentService.GetById(id);
            }
            catch (Exception exception)
            {
                responseBase = new ResponseBase<Department>(null)
                {
                    Success = false,
                    Message = exception.ToString()
                };
            }
            return Ok(responseBase);
        }

        // GET: api/Department
        [ResponseType(typeof(ResponseBase<IList<Department>>))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            ResponseBase<List<Department>> responseBase;

            try
            {
                responseBase = DepartmentService.GetList();
            }
            catch (Exception exception)
            {
                responseBase = new ResponseBase<List<Department>>(null)
                {
                    Message = exception.ToString(),
                    Success = false
                };
            }
            return Ok(responseBase);
        }

        // POST: api/Department
        [ResponseType(typeof(ResponseBase<Department>))]
        [HttpPost]
        public IHttpActionResult Post([FromBody] Department item)
        {
            ResponseBase<Department> responseBase;

            try
            {
                if (item == null)
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "that item doesn't exist anything"));

                responseBase = DepartmentService.Add(item);
            }
            catch (Exception exception)
            {
                responseBase = new ResponseBase<Department>(null)
                {
                    Success = false,
                    Message = exception.ToString()
                };
            }
            return Ok(responseBase);
        }

        // PUT: api/Department/1
        [ResponseType(typeof(ResponseBase<bool>))]
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Department item)
        {
            ResponseBase<bool> responseBase;

            try
            {
                if (item == null)
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "that item doesn't exist anything"));

                responseBase = DepartmentService.UpdateById(id, item);
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

        // DELETE: api/Department/1
        [ResponseType(typeof(ResponseBase<bool>))]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            ResponseBase<bool> responseBase;

            try
            {
                responseBase = DepartmentService.DeleteById(id);
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
