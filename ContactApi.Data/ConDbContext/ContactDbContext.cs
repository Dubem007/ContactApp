using ContactApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ContactApi.Data.ConDbContext
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {
        }

        protected ContactDbContext()
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
