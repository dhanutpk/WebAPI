using System.Collections.Generic;
using System.Web.Http;
using MvcAppWebApi.Models;
using System.Net;

namespace MvcAppWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        IContactRepository repository = new ContactModel();

        // GET /api/values
        [HttpGet]
        public IEnumerable<ContactDetail> Get()
        {
            return repository.GetAll();
        }

        // GET /api/values/5
        [HttpGet]
        public ContactDetail Get(int id)
        {
            ContactDetail contact = repository.GetById(id);
            if (contact == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return contact;
        }

        // POST /api/values
        [HttpPost]
        public void PostContact(ContactDetail contact)
        {
            repository.Add(contact);
        }

        // PUT /api/values
        [HttpPut]
        public void PutContact(ContactDetail contact)
        {
            if (repository.Update(contact)==0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        // DELETE /api/values/5
        [HttpDelete]
        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}