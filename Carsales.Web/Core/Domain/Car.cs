using System.Collections.Generic;

namespace Carsales.Core.Domain
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public PriceType PriceType { get; set; }
        public decimal? EgcPrice { get; set; }
        public decimal? DapPrice { get; set; }
        public string Email { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string DealerABN { get; set; }
        public string Comments { get; set; }
        public ICollection<Enquiry> Enquiries { get; set; }

        // Computed values: SQLite doesn't support computed columns so here's an alternative
        public string Name
        {
            get
            {
                return this.Year + " " + this.Make + " " + this.Model;
            }
        }

        public string Price
        {
            get
            {
                if (this.PriceType == PriceType.POA) return "Price";
                if (this.PriceType == PriceType.EGC && this.EgcPrice != null) return ((decimal)this.EgcPrice).ToString("$#,#");
                if (this.PriceType == PriceType.DAP && this.DapPrice != null) return ((decimal)this.DapPrice).ToString("$#,#");
                return "";
            }
        }
        public string PriceDesc
        {
            get
            {
                if (this.PriceType == PriceType.POA) return "On Application";
                if (this.PriceType == PriceType.EGC && this.EgcPrice != null) return "Excl. Govt. Charges";
                if (this.PriceType == PriceType.DAP && this.DapPrice != null) return "Drive Away";
                return "";
            }
        }

        public string SellerTypeText
        {
            get
            {
                return this.IsPrivateSellerCar ? "Private Seller" : "Dealer";
            }
        }

        public bool IsPrivateSellerCar
        {
            get
            {
                return string.IsNullOrEmpty(this.DealerABN);
            }
        }
    }
}