using System.Collections.Generic;
using System.Linq;

namespace MvcAppWebApi.Models
{
    public class ContactModel : IContactRepository
    {
        ContactEntities context = new ContactEntities();

        /// <summary>
        /// Gets All Contact
        /// </summary>
        /// <returns>All Contact Details</returns>
        public IEnumerable<ContactDetail> GetAll()
        {
            return context.ContactDetails;
        }

        /// <summary>
        /// Get Contact by Contact ID
        /// </summary>
        /// <param name="contactId">Contact Id</param>
        /// <returns>Contact Detail</returns>
        public ContactDetail GetById(int contactId)
        {
            IQueryable<ContactDetail> customers = context.ContactDetails.Where(a => a.ContactId == contactId);
            return customers.FirstOrDefault();
        }

        /// <summary>
        /// Updates Existing Contact
        /// </summary>
        /// <param name="contact">Contact</param>
        /// <returns>result</returns>
        public int Update(ContactDetail contact)
        {
            ContactDetail updateContact = context.ContactDetails.FirstOrDefault(c => c.ContactId == contact.ContactId);
            updateContact.FirstName = contact.FirstName.Trim();
            updateContact.MiddleName = contact.MiddleName.Trim();
            updateContact.LastName = contact.LastName.Trim();
            updateContact.EmailAddress = contact.EmailAddress.Trim();

            return context.SaveChanges();
        }

        /// <summary>
        /// Adds New Contact
        /// </summary>
        /// <param name="contact">Contact</param>
        public ContactDetail Add(ContactDetail contact)
        {
            var addedContact = context.ContactDetails.Add(contact);
            context.SaveChanges();

            return addedContact;
        }

        /// <summary>
        /// Deletes Contact
        /// </summary>
        /// <param name="contactId">Contact ID</param>
        public void Delete(int contactId)
        { 
            ContactDetail contact = context.ContactDetails.FirstOrDefault(a=>a.ContactId == contactId);
            context.ContactDetails.Remove(contact);
            context.SaveChanges();
        }
    }
}