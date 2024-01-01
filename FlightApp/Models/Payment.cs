using System.ComponentModel.DataAnnotations;

namespace FlightApp.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }


        public int CardNo { get; set; }


        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:/MM/yyyy}")]
        [Required(ErrorMessage = "Lütfen geçerli bir tarih seçiniz.")]
        public DateTime CardDate { get; set; }
        public int CVV { get; set; }


    }
}
