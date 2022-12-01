using ContactApi.Data.ConDbContext;
using ContactApi.Domain.Models;
using ContactApi.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactApi.Infrastructure.Repository
{
    public class ContactRepository<TEntity> : IRepository<Contact> where TEntity: class
    {
        private readonly ContactDbContext _contactDbContext;

        public ContactRepository(ContactDbContext contactDbContext)
        {
            _contactDbContext = contactDbContext;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _contactDbContext.Contacts.ToListAsync();
           
        }

        public void AddContactAsync(ContactDTO entity)
        {
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }
            var newContact = new Contact
            {
                Name = entity.Name,
                DateOfBirth = entity.DateOfBirth,
                Sex = entity.Sex,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber

            };
             _contactDbContext.Contacts.AddAsync(newContact);
             _contactDbContext.SaveChanges();
        }

        public void Remove(int id)
        {
            var entity = _contactDbContext.Contacts.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            _contactDbContext.Contacts.Remove(entity.Result);
             _contactDbContext.SaveChanges();
        }

        public async Task<Contact> GetById(int id)
        {
            var entity = await _contactDbContext.Contacts.FindAsync(id);
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }
            return entity;
        }
    }
}
