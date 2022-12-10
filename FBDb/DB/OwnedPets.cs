using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace WPF.DB
{
    internal class OwnedPets
    {
        //so basically any value has to exist in the pets table. based.
        [ForeignKey("Pet"),Key]
        public int PetId { get; set; }
    }
}
