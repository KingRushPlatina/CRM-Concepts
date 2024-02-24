using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;

namespace CRM_Concepts_Api.Models
{
    public class Client
    {
        [Key]
        public string Cf { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Sesso { get; set; }
        public string Email { get; set; }
       
    }


}
