using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.Web.Models
{
    public class Contact
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [JsonProperty("sex")]
        public string Sex { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
