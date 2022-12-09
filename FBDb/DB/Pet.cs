using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.DB
{
    internal class Pet
    {
        //[Required, MinLength(3, ErrorMessage = "Enter at least 3 characters"), MaxLength(5)]
        [Key]
        public int PetId { get; set; }
        //do not set this, let it generate! its also PK
        [MinLength(1), MaxLength(100)]
        public string Name { get; set; }
        [MinLength(1), MaxLength(500)]
        public string Description { get; set; }
        public double ToxGeneration { get; set; } //multipliers
        //[MaxLength=250]
        public int ToxProduced { get; set; }
        [MinLength(1), MaxLength(100)]
        public string Sprite { get; set; }

        //well isnt this the funniest thing you've ever seen
    }
}
