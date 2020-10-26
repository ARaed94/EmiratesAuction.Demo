using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Business.Implementations;
using DataAccess.Context;
using DataAccess.Contracts;
using DataAccess.Seeder;
using Entities.Modules.Core;
using Entities.Modules.Enums;
using Entities.Modules.Lookups;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IRepository<Auction> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public DemoController(IRepository<Auction> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        [HttpPost()]
        [Route("reset-data")]
        public ActionResult<BaseServiceResponse<string>> ResetData(int auctionsCount = 20)
        {
            BaseServiceResponse<string> response = new BaseServiceResponse<string>();
            try
            {
                if (auctionsCount == 0)
                {
                    response.Status = Enum.GetName(typeof(ResponseStatus), ResponseStatus.Failure);
                    response.Errors = "Please select a number of auctions to create.";
                    return StatusCode(StatusCodes.Status400BadRequest, response);
                }

                // Reset data.
                _repository.DeleteAll();

                // Get request data.
                string scheme = HttpContext.Request.Scheme;
                string hostname = HttpContext.Request.Host.Value;

                // Set random car details.
                Random random = new Random();

                // Load all car makes.
                List<Make> makes = new DataSeeder().GenerateCarMakes();

                // Create fake auction data.
                List<Auction> auctions = new List<Auction>();

                for (int i = 0; i < auctionsCount; i++)
                {
                    Auction auction = new Auction()
                    {
                        Lot = DataSeeder.RandomString(5),
                        EndDate = DateTime.Now.AddMinutes(random.Next(1, 3)).ToString("o"),
                        Bids = random.Next(1, 5000),
                        CurrencyAr = "درهم",
                        CurrencyEn = "AED",
                        MainHeroImageUrl = string.Format($"{scheme}://{hostname}/Content/Images/car{random.Next(0, 9)}.jpg"),
                        CurrentBid = random.Next(10000, 200000),
                        Year = random.Next(1980, 2020),
                        CreatedOn = DateTime.Now
                    };

                    auction.MakeId = random.Next(1, 5);
                    auction.MakeAr = makes.FirstOrDefault(make => make.Id == auction.MakeId).TitleAr;
                    auction.MakeEn = makes.FirstOrDefault(make => make.Id == auction.MakeId).TitleEn;

                    auction.ModelId = random.Next(1, 5);
                    auction.ModelAr = string.Format($"موديل {auction.ModelId}");
                    auction.ModelEn = string.Format($"Model {auction.ModelId}");

                    auction.TrimId = random.Next(1, 5);
                    auction.TrimAr = string.Format($"نوع {auction.TrimId}");
                    auction.TrimEn = string.Format($"Trim {auction.TrimId}");

                    auction.AuctionDetail = new AuctionDetail()
                    {
                        CarId = random.Next(1, 999),
                        AuctionPriorityId = (AuctionPriority)random.Next(Enum.GetNames(typeof(AuctionPriority)).Length),
                        Vin = DataSeeder.RandomString(20),
                        VatPercentage = 5,
                        ItemId = random.Next(1, 100),
                        MinBidIncrement = 1000,
                        ImagesCount = 3,
                        DescriptionAr = LoremIpsumGenerator.Generate(2, 5, 1, 2, 1, Language.Arabic),
                        DescriptionEn = LoremIpsumGenerator.Generate(2, 5, 1, 2, 1, Language.English),
                        BodyAr = LoremIpsumGenerator.Generate(2, 5, 1, 2, 1, Language.Arabic),
                        BodyEn = LoremIpsumGenerator.Generate(2, 5, 1, 2, 1, Language.English),
                        SharingMessageAr = LoremIpsumGenerator.Generate(2, 5, 1, 2, 1, Language.Arabic),
                        SharingMessageEn = LoremIpsumGenerator.Generate(2, 5, 1, 2, 1, Language.English),
                        SharingLink = LoremIpsumGenerator.Generate(2, 5, 1, 2, 1, Language.English),
                        Mileage = random.Next(1, 300000),
                        CreatedOn = DateTime.Now
                    };
                    auctions.Add(auction);
                }

                _repository.Insert(auctions);
                _unitOfWork.SaveChanges();

                response.Status = Enum.GetName(typeof(ResponseStatus), ResponseStatus.Success);
                response.Result = "Data reset was successful.";
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
