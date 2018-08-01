using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
 
namespace LostandFoundAnimals.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class PostIndexData
    {

        public IEnumerable<Post> Posts { get; set; }
        public Address Address { get; set; }
        public Animal Animal { get; set; }
        public Species Species { get; set; }
        public IEnumerable<Breed> Breeds {get;set;}

    }


}
