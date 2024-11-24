namespace Login.DTOs
{
    public class ReservationDetailsDTO
    {
        public int ReservationId { get; set; }
        public string Email { get; set; }  // User's email associated with the reservation
        public string Make { get; set; }   // Car make
        public string Model { get; set; }  // Car model
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public decimal Amount { get; set; }
        
    }

}
