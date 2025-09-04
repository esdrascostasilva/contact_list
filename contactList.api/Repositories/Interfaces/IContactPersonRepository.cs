using System;
using contactList.api.Models;

namespace contactList.api.Repositories.Interfaces;

public interface IContactPersonRepository
{
    Task<List<ContactPerson>> GetAll();
    Task<List<ContactPerson>> GetByName(string name);
    Task<ContactPerson> Create(ContactPerson contactPerson);
    Task<bool> Update(Guid id, ContactPerson contactPerson);
    Task<bool> Delete(Guid id);
}
