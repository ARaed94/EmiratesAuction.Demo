using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using API.Models;
using DataAccess.Contracts;
using Entities.Modules.Lookups;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IRepository<Model> _repository;

        public ModelsController(IRepository<Model> repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        [Route("")]
        public ActionResult<BaseServiceResponse<ArrayResponse<Model>>> FindAll()
        {
            BaseServiceResponse<ArrayResponse<Model>> response = new BaseServiceResponse<ArrayResponse<Model>>();
            try
            {
                Expression<Func<Model, bool>> filter = make => make.DeletedOn == null;

                List<Model> models = _repository.FindAll(null, filter);

                response.Status = Enum.GetName(typeof(ResponseStatus), ResponseStatus.Success);
                response.Result = new ArrayResponse<Model>()
                {
                    Data = models,
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