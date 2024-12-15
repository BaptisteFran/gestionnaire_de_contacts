namespace gestionnaire_de_contacts;

public class Contact
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }

    public static Contact Create(string firstName, string lastName, string phone)
    {
        Contact contact = new Contact();
        contact.FirstName = firstName;
        contact.LastName = lastName;
        contact.Phone = phone;
        return contact;
    }
}