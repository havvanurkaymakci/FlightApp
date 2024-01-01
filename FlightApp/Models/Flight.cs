using System.ComponentModel.DataAnnotations;

namespace FlightApp.Models
{
    public class Flight
    {

        [Key]
        public int FlightId { get; set; }


        [Display(Name = "Ucuş numarası")]
        public string FlightNumber { get; set; } // ucus numarası

        [Display(Name = "Kalkış yeri")]
        public string FlightDeparture { get; set; }

        [Display(Name = "Varış yeri")]
        public string FlightDestination { get; set; }


        [Display(Name = "kalkış tarihi")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Lütfen geçerli bir tarih seçiniz.")]
        public DateTime FlightDepartureDate { get; set; }

        [Display(Name = "Varış tarihi")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Lütfen geçerli bir tarih seçiniz.")]
        public DateTime FlightDestinationDate { get; set; }


        [Display(Name = "Uçuş fiyatı")]
        public double FlightPrice { get; set; }
    }
}
