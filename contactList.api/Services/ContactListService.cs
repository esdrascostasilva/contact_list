using System;
using contactList.api.Models;
using contactList.api.Repositories.Interfaces;
using contactList.api.Services.Interfaces;

namespace contactList.api.Services;

public class ContactListService : IContactListService
{
    private readonly IContactPersonRepository _contactRepository;

    public ContactListService(IContactPersonRepository personRepository)
    {
        _contactRepository = personRepository;
    }

    public async Task<ResponseContactPerson> CreateContactAsync(ContactPerson contactPerson)
    {
        var contact = await _contactRepository.Create(contactPerson);

        if (contact == null)
            throw new Exception("Ocorreu um problema ao criar o contato na sua lista.");

        var contactResponse = new ResponseContactPerson
        {
            Name = contactPerson.Name,
            Phone = contactPerson.Phone,
            Group = contactPerson.Group
        };

        return contactResponse;
    }

    public async Task<bool> DeleteContactAsync(Guid id)
    {
        var isDeleted = await _contactRepository.Delete(id);

        if (isDeleted == false)
            throw new Exception("Ocorreu um problema ao excluir o contato da sua lista.");

        return true;
    }

    public async Task<List<ContactPerson>> GetAllContactsAsync()
    {
        var contact = await _contactRepository.GetAll();

        if (contact == null)
            throw new Exception("Nao ha contatos em sua lista");

        return contact;
    }

    public async Task<List<ContactPerson>> GetContactByNameAsync(string name)
    {
        var contacts = await _contactRepository.GetByName(name);

        if (contacts == null)
            throw new Exception($"Nao existe um contatco com esse nome: ${name} na sua lista de contatos.");

        return contacts;
    }

    public async Task<bool> UpdateContactAsync(Guid id, ContactPerson requestContactPerson)
    {
        var isUpdated = await _contactRepository.Update(id, requestContactPerson);

        if (isUpdated == false)
            throw new Exception("Ocorreu um erro ao atualizar o contato na sua lista.");

        return true;
    }
}
