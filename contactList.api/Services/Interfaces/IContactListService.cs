using System;
using contactList.api.Models;

namespace contactList.api.Services.Interfaces;

public interface IContactListService
{
    Task<List<ContactPerson>> GetAllContactsAsync();
    Task<List<ContactPerson>> GetContactByNameAsync(string name);
    Task<ResponseContactPerson> CreateContactAsync(ContactPerson contactPerson);
    Task<bool> UpdateContactAsync(Guid id, ContactPerson requestContactPerson);
    Task<bool> DeleteContactAsync(Guid id);
}
 