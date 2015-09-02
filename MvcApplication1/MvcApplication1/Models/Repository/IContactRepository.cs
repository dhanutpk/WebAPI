using System.Collections.Generic;

namespace MvcAppWebApi.Models
{
    public interface IContactRepository
    {
        IEnumerable<ContactDetail> GetAll();
        ContactDetail GetById(int customerId);
        int Update(ContactDetail contact);
        ContactDetail Add(ContactDetail contact);
        void Delete(int contactId);
    }
}