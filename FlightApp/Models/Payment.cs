using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FlightApp.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        //[ForeignKey("FlightId")]
        //Flight flight { get; set; }
        //public string flightNumber {  get; set; }   

        public int TotalAmount { get; set; }
        public int CardNo { get; set; }


        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:/MM/yyyy}")]
        [Required(ErrorMessage = "Lütfen geçerli bir tarih seçiniz.")]
        public DateTime CardDate { get; set; }
        public int CVV { get; set; }

        [ForeignKey("PassengerId")]
        public Passenger? Passenger { get; set; }
        public string? PassengerName { get; set; }
        public string? PassengerSurname { get; set; }




    }
}

