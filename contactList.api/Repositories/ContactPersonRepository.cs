using System;
using contactList.api.Data;
using contactList.api.Models;
using contactList.api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace contactList.api.Repositories;

public class ContactPersonRepository : IContactPersonRepository
{
    private readonly ContactContext _context;

    public ContactPersonRepository(ContactContext contactContext)
    {
        _context = contactContext;
    }

    public async Task<ContactPerson> Create(ContactPerson contactPerson)
    {
        var contact = new ContactPerson
        {
            Id = Guid.NewGuid(),
            Name = contactPerson.Name,
            Phone = contactPerson.Phone,
            Phone2 = contactPerson.Phone2,
            Email = contactPerson.Email,
            Address = contactPerson.Address,
            Group = contactPerson.Group
        };

        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();

        return contact;
    }

    public async Task<List<ContactPerson>> GetAll()
    {
        var contacts = await _context.Contacts.ToListAsync();

        return contacts;
    }

    public async Task<List<ContactPerson>> GetByName(string name)
    {
        // retorno o contato com o nome, distinguindo maiuscula de minuscula
        // var contact = await _context.Contacts.FirstOrDefaultAsync(contact => contact.Name.ToLower() == name.ToLower());

        // retorno ao nome correspondente
        var contact = await _context.Contacts
            .Where(contact => contact.Name.ToLower().Contains(name.ToLower()))
            .ToListAsync();

        return contact;
    }

    public async Task<bool> Update(Guid id, ContactPerson contactPerson)
    {
        var contact = await _context.Contacts.FindAsync(id);

        contact.Name = contactPerson.Name;
        contact.Phone = contactPerson.Phone;
        contact.Phone2 = contactPerson.Phone2;
        contact.Email = contactPerson.Email;
        contact.Address = contactPerson.Address;
        contact.Group = contactPerson.Group;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Delete(Guid id)
    {
        var contact = await _context.Contacts.FindAsync(id);

        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();

        return true;
    }
}
