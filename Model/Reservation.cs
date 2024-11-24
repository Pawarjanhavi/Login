using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Login.Model
{
    public enum Status
    {
        Confirmed= 1,
        Cancelled = 2
    }

 
    public class Reservation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationId { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime PickUpDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DropOffDate { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }

        //navigation properties
        public User user { get; set; }
        public Car car { get; set; }
        public ICollection<Payment> payments { get; set; }
    }
}
