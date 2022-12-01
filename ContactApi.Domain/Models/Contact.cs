using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContactApi.Domain.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Sex { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }



    public class ContactDisplay
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [JsonProperty("Sex")]
        public string Sex { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("PhoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
