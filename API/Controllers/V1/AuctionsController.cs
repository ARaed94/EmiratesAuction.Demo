using API.Models;
using DataAccess.Contracts;
using DataAccess.Query;
using Entities.Modules.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuctionsController : ControllerBase
    {
        private readonly IRepository<Auction> _repository;

        public AuctionsController(IRepository<Auction> repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        [Route("")]
        public ActionResult<BaseServiceResponse<ArrayResponse<Auction>>> FindAll(int? makeId, int? modelId, int? trimId,
            int? year, int pageNumber = 1, int pageSize = 10)
        {
            BaseServiceResponse<ArrayResponse<Auction>> response = new BaseServiceResponse<ArrayResponse<Auction>>();
            try
            {
                Pagination pagination = new Pagination() { PageNumber = pageNumber, PageSize = pageSize };

                #region Filter Data
                Expression<Func<Auction, bool>> filter = auction => auction.DeletedOn == null;
                if (makeId.HasValue && makeId.Value > 0)
                {
                    filter = filter.And(auction => auction.MakeId == makeId.Value);
                }

                if (modelId.HasValue && modelId.Value > 0)
                {
                    filter = filter.And(auction => auction.ModelId == modelId.Value);
                }

                if (trimId.HasValue && trimId.Value > 0)
                {
                    filter = filter.And(auction => auction.TrimId == trimId.Value);
                }

                if (year.HasValue && year.Value > 0)
                {
                    filter = filter.And(auction => auction.Year == year.Value);
                }
                #endregion

                List<Auction> auctions = _repository.FindAll(pagination, filter);

                response.Status = Enum.GetName(typeof(ResponseStatus), ResponseStatus.Success);
                response.ServerTime = DateTime.Now.ToString("o");
                response.Result = new ArrayResponse<Auction>()
                {
                    Data = auctions,
                    Pagination = pagination
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

        [HttpGet()]
        [Route("{id}")]
        public ActionResult<BaseServiceResponse<Auction>> FindById([FromRoute] int id)
        {
            BaseServiceResponse<Auction> response = new BaseServiceResponse<Auction>();
            try
            {
                Expression<Func<Auction, bool>> filter = auction => auction.DeletedOn == null;

                Auction auction = _repository.Find(id);

                if (auction == null)
                {
                    response.Status = Enum.GetName(typeof(ResponseStatus), ResponseStatus.NotFound);
                    response.Errors = "The requested resource was not found.";
                    return NotFound(response);
                }
                else
                {
                    response.Status = Enum.GetName(typeof(ResponseStatus), ResponseStatus.Success);
                    response.Result = auction;
                    return Ok(response);
                }
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
