using Carsales.Core.Domain;

namespace Carsales.Web.ViewModels
{
    public class CarDetailsViewModel
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public PriceType PriceType { get; set; }
        public decimal? EgcPrice { get; set; }
        public decimal? DapPrice { get; set; }
        public string Comments { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string PriceDesc { get; set; }
        public SellerDetailsViewModel SellerDetailsViewModel { get; set; }
        public EnquiryAddViewModel EnquiryAddViewModel { get; set; }
    }
}
