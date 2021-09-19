using Microsoft.AspNetCore.Mvc.RazorPages;
using OtiumActio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OtiumActio.ViewModels
{
    public class ActivityViewModel 
    {
        public int Id { get; set; }
        public int Category { get; set; }
        public Category Categories { get; set; }
        [Required(AllowEmptyStrings= false, ErrorMessage = "Skriv in en kort beskrivning av aktiviteten...")]
        public string Description { get; set; }
        [Range(1, 8, ErrorMessage = "Antal deltagande måste vara mellan 1 och 8")]
        public long Participants { get; set; }
        public DateTime Date { get; set; }
    }
}
