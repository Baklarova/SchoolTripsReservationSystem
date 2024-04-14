namespace SchoolTripsReservationSystem.Core.Models.Home
{
    public class HomeViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        public string Description { get; set; } = string.Empty;

        public decimal PricePerStudent { get; set; }
        
        public decimal PricePerAdult { get; set; }
       
        public int RegionId { get; set; }
    }
}
