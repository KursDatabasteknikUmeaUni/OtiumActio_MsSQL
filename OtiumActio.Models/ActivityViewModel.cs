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
        public Category Categories { get; set; }

        [Required(AllowEmptyStrings= false, ErrorMessage = "Beskriv kort aktiviteten, max 50 karaktär")]
        public string Description { get; set; }
        [Range(1, 50, ErrorMessage = "På grund av rådande restriktioner får antal deltagande inte överskrida 50")]
        public long Participants { get; set; }
        //[Range(typeof(DateTime), DateTime.Now.ToString(), "31/12/2021", ErrorMessage ="")]
        [DisplayFormat(DataFormatString = "{0:mm-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
    }
}
