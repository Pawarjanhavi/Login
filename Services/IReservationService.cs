using Login.DTOs;
using Login.Model;

namespace Login.Services
{
    public interface IReservationService
    {
        public string CreateReservation(ReservationRequestDTO dto);
        public string UpdateReservation(ReservationRequestDTO dto);
        public ReservationDetailsDTO GetReservationDetails(string email);
       // public IEnumerable<ReservationHistoryDTO> GetReservationHistory(string userEmail);
       public string CancelReservation(string email);
       public  string DeleteReservation(string email);
    }
}
