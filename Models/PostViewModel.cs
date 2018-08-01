using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LostandFoundAnimals.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class PostViewModel
    {
        //public PostViewModel(){
        //    Breeds = new ICollection<Breed>();
        //}
        public Post Post { get; set; }
        public Address Address { get; set; }
        public Animal Animal { get; set; }
        public List<Species> SpeciesList { get; set; }
        //public ICollection<Breed> Breeds { get; set; }
        public Breed Breed1 { get; set; }
        public Breed Breed2 { get; set; }
    }

}
