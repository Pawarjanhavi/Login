using System;
using System.Linq;
using Login.Model;
using Login.DTOs;
using Login.Data;
using Login.Services;
using Microsoft.EntityFrameworkCore;

namespace Login.Repository
{
    public class ReservationRepo : IReservationService
    {
        private readonly ApplicationDBContext _dbContext;

        public ReservationRepo(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string CreateReservation(ReservationRequestDTO dto)
        {
            try
            {
                // Find the user by email
                var user = _dbContext.Users.FirstOrDefault(u => u.Email == dto.Email);
                if (user == null)
                {
                    return "User not found"; // Return message if user does not exist
                }

                // Find the car by make and availability status
                var car = _dbContext.Cars.FirstOrDefault(c => c.Make == dto.Make && c.AvailableStatus);
                if (car == null)
                {
                    return "Car not available"; // Return message if car does not exist or is not available
                }

                // Ensure pickUpDate and dropOffDate are non-null and valid
                DateTime pickUpDate = dto.PickUpDate;
                DateTime dropOffDate = dto.DropOffDate;

                if (dropOffDate <= pickUpDate)
                {
                    return "Invalid reservation: Drop-off date must be after the pick-up date."; // Invalid date range
                }

                // Calculate rental duration in days
                TimeSpan rentalDuration = dropOffDate - pickUpDate;

                // Calculate the reservation amount based on rental duration
                var amount = (decimal)rentalDuration.TotalDays * car.PricePerDay;

                // Create the reservation entity
                var reservation = new Reservation
                {
                    UserId = user.UserId,
                    CarId = car.CarId,
                    PickUpDate = pickUpDate,
                    DropOffDate = dropOffDate,
                    Amount = amount,
                    Status = Status.Confirmed
                };

                // Add reservation to the database
                _dbContext.Reservations.Add(reservation);

                // Update the car availability status to false (indicating it is reserved)
                car.AvailableStatus = false;

                // Save changes to the database
                _dbContext.SaveChanges();

                return "Reservation created successfully."; // Return success message
            }
            catch (Exception ex)
            {
                // Log the exception (or return the error message)
                return $"Error during reservation creation: {ex.Message}";
            }
        }

        public string UpdateReservation(ReservationRequestDTO dto)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == dto.Email);

            if (user == null)
            {
                return "User not found.";
            }

            var reservation = _dbContext.Reservations.FirstOrDefault(r => r.UserId == user.UserId); // Assuming UserId is a foreign key in Reservation table

            if (reservation == null)
            {
                return "Reservation not found.";
            }

            // Check if the pickUpDate and dropOffDate are valid
            if (dto.PickUpDate != null && dto.DropOffDate != null && dto.PickUpDate < dto.DropOffDate)
            {
                reservation.PickUpDate = dto.PickUpDate;
                reservation.DropOffDate = dto.DropOffDate;

                // Save the changes to the database
                _dbContext.SaveChanges();

                return "Reservation updated successfully.";
            }

            return "Invalid dates: Drop-off date must be after pick-up date.";

        }

        public ReservationDetailsDTO GetReservationDetails(string email)
        {
            try
            {
                // Fetch the user based on the provided email
                var user = _dbContext.Users
                    .FirstOrDefault(u => u.Email == email);

                if (user == null)
                {
                    throw new Exception("User not found.");
                }

                // Fetch the reservation based on the user ID
                var reservation = _dbContext.Reservations
                    .FirstOrDefault(r => r.UserId == user.UserId);

                if (reservation == null)
                {
                    throw new Exception("Reservation not found for this user.");
                }

                // Fetch the car details associated with this reservation
                var car = _dbContext.Cars
                    .FirstOrDefault(c => c.CarId == reservation.CarId);

                if (car == null)
                {
                    throw new Exception("Car details not found for this reservation.");
                }

                // Create the ReservationDetailsDTO to return
                var reservationDetailsDto = new ReservationDetailsDTO
                {
                    ReservationId = reservation.ReservationId,
                    Email = user.Email,  // User's email associated with the reservation
                    Make = car.Make,     // Car make
                    Model = car.Model,   // Car model
                    PickUpDate = reservation.PickUpDate,
                    DropOffDate = reservation.DropOffDate,
                    Amount = reservation.Amount,
                    
                };

                return reservationDetailsDto;
            }
            catch (Exception ex)
            {
                // Handle errors and return the exception message
                throw new Exception($"Error fetching reservation details: {ex.Message}");
            }
        }

        public string DeleteReservation(string email)
        {
            // Fetch the user based on the email
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return "User not found.";  // Handle case where the user does not exist
            }

            // Fetch the reservation based on the user ID
            var reservation = _dbContext.Reservations
                .FirstOrDefault(r => r.UserId == user.UserId);  // Match with the user ID

            if (reservation == null)
            {
                return "Reservation not found.";  // Handle case where reservation doesn't exist
            }

            // Remove the reservation from the database
            _dbContext.Reservations.Remove(reservation);
            _dbContext.SaveChanges();

            return "Reservation deleted successfully.";  // Return success message
        }



        public string CancelReservation(string email)
        {
            // Fetch the user based on the email
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return "User not found."; // Handle case where the user does not exist
            }

            // Find the reservation for this user
            var reservation = _dbContext.Reservations
                .FirstOrDefault(r => r.UserId == user.UserId && r.Status == Status.Confirmed); // Use Status.Cancelled for comparison
            if (reservation == null)
            {
                return "Reservation not found or already canceled."; // Handle case where the reservation does not exist or is already canceled
            }

            // Update the status of the reservation to "Cancelled"
            reservation.Status = Status.Cancelled; // Assuming Status is an enum with a value 'Cancelled'
            _dbContext.SaveChanges();

            return "Reservation canceled successfully."; // Return success message
        }

    }
}
