using ContactApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactApi.Infrastructure.Interface
{
    public interface IRepository<Contact> where Contact : class
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetById(int id);
        void AddContactAsync(ContactDTO entity);
        void Remove(int id);
    }
}
