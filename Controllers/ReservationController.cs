using System;
using Microsoft.AspNetCore.Mvc;
using Login.Services;
using Login.DTOs;
using Login.Data;
using Login.Repository;

namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost("ReserveCar")]
        public IActionResult ReserveCar([FromForm] string email, [FromForm] string make, [FromForm] DateTime? pickUpDate, [FromForm] DateTime? dropOffDate)
        {
            try
            {
                // Set pickUpDate to today's date if it's null
                pickUpDate = pickUpDate ?? DateTime.Today;

                // Set dropOffDate to pickUpDate + 1 day if it's null
                dropOffDate = dropOffDate ?? pickUpDate.Value.AddDays(1);

                // Create the reservation object
                var reservationRequest = new ReservationRequestDTO
                {
                    Email = email,
                    Make = make,
                    PickUpDate = pickUpDate.Value,
                    DropOffDate = dropOffDate.Value
                };

                // Call the service to create the reservation
                var result = _reservationService.CreateReservation(reservationRequest);

                if (result == "Reservation created successfully.")
                {
                    return Ok(new { Message = result });
                }

                return BadRequest(new { Message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error during reservation", Details = ex.Message });
            }
        }

        // PUT: api/reservation/update
        [HttpPut("update")]
        public IActionResult UpdateReservation([FromForm] string email, [FromForm] string make, [FromForm] DateTime? pickUpDate, [FromForm] DateTime? dropOffDate)
        {
            if (string.IsNullOrEmpty(email) || pickUpDate == null || dropOffDate == null)
            {
                return BadRequest("Missing required data.");
            }

            var reservationRequest = new ReservationRequestDTO
            {
                Email = email,
                Make = make,
                PickUpDate = pickUpDate.Value,
                DropOffDate = dropOffDate.Value
            };
            // Call the service to create the reservation
            var result = _reservationService.UpdateReservation(reservationRequest);

            // Return the result based on the service response
            if (result == "Reservation updated successfully.")
            {
                return Ok(new { Message = result });
            }
            else
            {
                return BadRequest(new { Message = result });
            }
        }


        [HttpGet]
        [Route("details/{email}")]
        public IActionResult GetReservationDetails(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email is required.");
            }

            try
            {
                var reservationDetails = _reservationService.GetReservationDetails(email);
                return Ok(reservationDetails);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }


        [HttpDelete("delete")]
        public IActionResult DeleteReservation([FromQuery] string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email is required.");
            }

            var result = _reservationService.DeleteReservation(email); // Pass email string to the service method

            if (result == "Reservation deleted successfully.")
            {
                return Ok(result);
            }

            return BadRequest(result); // Return error message in case of failure
        }


        [HttpPost("Cancel")]
        public IActionResult CancelReservation([FromForm] string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email is required to cancel a reservation.");
            }

            try
            {
                // Call the service to cancel the reservation
                var result = _reservationService.CancelReservation(email);

                if (result.Contains("successfully"))
                {
                    return Ok(new { message = result });
                }
                else
                {
                    return NotFound(new { message = result });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while canceling the reservation.", details = ex.Message });
            }
        }
    }
}
