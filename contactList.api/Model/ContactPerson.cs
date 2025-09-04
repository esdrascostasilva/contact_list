using System;

namespace contactList.api.Model;

public class ContactPerson
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Phone { get; set; }
    public string? Phone2 { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public required string Group { get; set; }
}

public class ResponseContactPerson
{
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Group { get; set; }
}