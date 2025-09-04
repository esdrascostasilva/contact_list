using System;
using contactList.api.Models;
using Microsoft.EntityFrameworkCore;

namespace contactList.api.Data;

public class ContactContext : DbContext
{
    public ContactContext(DbContextOptions<ContactContext> options) : base(options)
    {
    }

    public DbSet<ContactPerson> Contacts { get; set; }
}
