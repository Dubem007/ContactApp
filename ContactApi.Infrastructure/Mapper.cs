using AutoMapper;
using ContactApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApi.Infrastructure
{
    public class Mapper : Profile
    {
        public Mapper()
        {
                CreateMap<Contact, ContactDisplay>();
                CreateMap<ContactDisplay, Contact>();
        }
        
    }
}
