using API.Models;
using DataAccess.Contracts;
using Entities.Modules.Lookups;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MakesController : ControllerBase
    {
        private readonly IRepository<Make> _repository;

        public MakesController(IRepository<Make> repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        [Route("")]
        public ActionResult<BaseServiceResponse<ArrayResponse<Make>>> FindAll()
        {
            BaseServiceResponse<ArrayResponse<Make>> response = new BaseServiceResponse<ArrayResponse<Make>>();
            try
            {
                Expression<Func<Make, bool>> filter = make => make.DeletedOn == null;

                List<Make> makes = _repository.FindAll(null, filter);

                response.Status = Enum.GetName(typeof(ResponseStatus), ResponseStatus.Success);
                response.Result = new ArrayResponse<Make>()
                {
                    Data = makes,
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = Enum.GetName(typeof(ResponseStatus), ResponseStatus.Failure);
                response.Errors = ex.ToString();
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
