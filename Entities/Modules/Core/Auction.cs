using Entities.Base;
using Entities.Modules.Lookups;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Modules.Core
{
    public class Auction : BaseEntity
    {
        #region Properties
        public string MakeAr { get; set; }
        public string MakeEn { get; set; }
        public int? MakeId { get; set; }
        public string ModelAr { get; set; }
        public string ModelEn { get; set; }
        public int? ModelId { get; set; }
        public string MainHeroImageUrl { get; set; }
        public int Year { get; set; }
        public string Lot { get; set; }
        public string CurrencyAr { get; set; }
        public string CurrencyEn { get; set; }
        public double CurrentBid { get; set; }
        public int Bids { get; set; }
        public string TrimAr { get; set; }
        public string TrimEn { get; set; }
        public int? TrimId { get; set; }
        public string EndDate { get; set; }

        #endregion

        #region Navigation Properties
        public Make Make { get; set; }
        public Model Model { get; set; }
        public Trim Trim { get; set; }
        public AuctionDetail AuctionDetail { get; set; }
        #endregion

        #region Not Mapped Properties
        #endregion
    }
}
