namespace Login.DTOs
{
    public class ReservationRequestDTO
    {
        public string Email { get; set; } // User's email for identifying the reservation
        public string Make { get; set; }  // The car make to identify the reservation's car
        public DateTime PickUpDate { get; set; }  // Optional: Pickup date from the user, can be null
        public DateTime DropOffDate { get; set; } // Optional: Dropoff date from the user, can be null
    }
}
