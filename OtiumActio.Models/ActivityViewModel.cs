using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OtiumActio;
using System.Threading.Tasks;

namespace OtiumActio.Models
{
    public class ActivityViewModel 
    {
        public int Id { get; set; }
        public int Category { get; set; }
        [Required(ErrorMessage = "Var god och välj en kategori")]

        public Category Categories { get; set; }

        [Required(AllowEmptyStrings= false, ErrorMessage = "Beskriv kort aktiviteten, max 50 karaktär")]
        public string Description { get; set; }
        [Range(1, 8, ErrorMessage = "Antal deltagande måste vara mellan 1 och 8")]
        public long Participants { get; set; }
        public DateTime Date { get; set; }
    }
}
