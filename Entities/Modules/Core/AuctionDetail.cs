using Entities.Base;
using Entities.Modules.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Modules.Core
{
    public class AuctionDetail : BaseEntity
    {
        public string SharingLink { get; set; }
        public string SharingMessageAr { get; set; }
        public string SharingMessageEn { get; set; }
        public decimal Mileage { get; set; }
        public int ImagesCount { get; set; }
        public int CarId { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public string BodyAr { get; set; }
        public string BodyEn { get; set; }
        public int MinBidIncrement { get; set; }
        public AuctionPriority AuctionPriorityId { get; set; }
        public decimal VatPercentage { get; set; }
        public int ItemId { get; set; }
        public string Vin { get; set; }
        public Auction Auction { get; set; }
        public int AuctionId { get; set; }
    }
}
