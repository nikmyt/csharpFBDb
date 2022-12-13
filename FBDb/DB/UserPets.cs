using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF.DB
{
    internal class UserPets
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key, Column(Order = 0)] //i stole this off internet pls work. oh right id generate themselfv
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
        public bool isOwnedByThisUser { get; set; } //its bit! but returs 0/1 never null
    }
}
