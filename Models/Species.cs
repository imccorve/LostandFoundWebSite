using System;
using System.Collections.Generic;

namespace LostandFoundAnimals.Models
{
    public class Species
    {
        public string SpeciesName { get; set; }
        public int SpeciesID { get; set; }

        public ICollection<Animal> Animals { get; set; }
    }
}
