using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace LostandFoundAnimals.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class PostViewModel
    {
        public Post Post { get; set; }
        public Address Address { get; set; }
        public Animal Animal { get; set; }
        public Breed Breed { get; set; }
    }


}
