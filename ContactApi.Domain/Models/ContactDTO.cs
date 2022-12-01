using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApi.Domain.Models
{
    public class ContactDTO
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
