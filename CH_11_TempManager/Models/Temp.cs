using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;

namespace CH_11_TempManager.Models
{
    public class Temp
    {
        
        public int Id { get; set; }
        
        [Required (ErrorMessage = "Date is required")]
        [Remote(action:"CheckDate", controller:"Validation")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:yyyy-MM-dd}" )]
        public DateTime? Date { get; set; }
        
        [Required(ErrorMessage = "Low temperature is required")]
        [Range(-200, 200, ErrorMessage = "The lowest temperature must be below -200 and 200 ")]
        public double? Low { get; set; }
        
        [Required (ErrorMessage = "High temperature is required")]
        [Range(-200, 200, ErrorMessage = "Highest temperature must be 200")]
        public double? High { get; set; }
    }
}
