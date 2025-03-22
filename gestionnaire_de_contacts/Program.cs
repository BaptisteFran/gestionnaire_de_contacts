// Gestionnaire de contacts par Jibé

/*
Gestionnaire de contacts
Objectifs : Manipuler des listes et créer des classes simples
Fonctionnalités :
 - Ajouter, supprimer, modifier et afficher les contacts (nom, numéro de téléphone)
 - Stocker les contacts dans une structure de données comme une List<Contact>
*/

using gestionnaire_de_contacts;

public class GestionnaireDeContacts
{
    public static void Main() 
    {
        bool running = true;
        List<Contact> contacts = new List<Contact>();
        Console.WriteLine("Welcome into the contact manager system !");
        string[] options = ["1", "2", "3", "4", "5"];

        while (running)
        {
            Console.WriteLine("Please enter an option :");
            Console.WriteLine("1. Add contact");
            Console.WriteLine("2. View contact");
            Console.WriteLine("3. Edit contact");
            Console.WriteLine("4. Delete contact");
            Console.WriteLine("5. Exit");
            string option = Console.ReadLine();
            
            if (!options.Contains(option))
            {
                Console.WriteLine("Please enter a valid option :");
                Console.WriteLine("1. Add contact");
                Console.WriteLine("2. View contact");
                Console.WriteLine("3. Edit contact");
                Console.WriteLine("4. Delete contact");
                Console.WriteLine("5. Exit");
                option = Console.ReadLine();
            }

            switch (option)
            {
                case "1":
                    Console.WriteLine("Enter contact first name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter contact last name: ");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Enter contact phone number: ");
                    string phone = Console.ReadLine();
                    SetContacts(contacts, name, lastName, phone);
                    option = "";
                    break;
                case "2":
                    Console.WriteLine("Enter the first name, last name or full name of a contact :");
                    string search = Console.ReadLine();
                    GetContacts(contacts, search);
                    option = "";
                    break;
                case "3":
                    Console.WriteLine("Enter the first name, last name or full name of a contact :");
                    string searchEdit = Console.ReadLine();
                    EditContact(contacts, searchEdit);
                    break;
                case "4":
                    Console.WriteLine("Enter the first name, last name or full name of a contact :");
                    string searchDelete = Console.ReadLine();
                    DeleteContact(contacts, searchDelete);
                    break;
                case "5":
                    running = false;
                    break;
            }
        }
    }

    private static bool SetContacts(List<Contact> contacts, string firstName, string lastName, string phone)
    {
        var contact = Contact.Create(firstName, lastName, phone);
        try
        {
            contacts.Add(contact);
            Console.WriteLine("Contact added successfully");
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("There was an error adding the contact : " + e.Message);
            return false;
        }
    }

    private static Contact GetContacts(List<Contact> contacts, string search)
    {
        Contact contact = null;
        if (contacts.Count == 0)
        {
            throw new Exception("There are no contacts");
        }
        
        if (string.IsNullOrEmpty(search))
        {
            throw new Exception("You must enter at least one contact first/last name or full name");
        }
       
        string[] names = search.Split(' ');
        try
        {
            contact = contacts.Find(contact =>
                contact.FirstName == names[0] || contact.LastName == names[1] ||
                contact.FirstName == names[1] || contact.LastName == names[0]);
            Console.WriteLine("Contact found : ");
            DisplayContact(contact);
        }
        catch (Exception e)
        {
            throw new ArgumentException("There was an error getting the contact : " + e.Message);
        }
        return contact;
    }

    private static void EditContact(List<Contact> contacts, string search = null)
    {
        if (contacts.Count == 0)
        {
            throw new Exception("There are no contacts");
        }
        
        if (string.IsNullOrEmpty(search))
        {
            throw new Exception("You must enter at least one contact first/last name or full name");
        }
        
        var contact = GetContacts(contacts, search);
        contacts.Remove(contact);
        
        string[] editOptions = ["1", "2", "3", "4"];
        Console.WriteLine("Choose an option to update the contact :");
        Console.WriteLine("1. Edit first name");
        Console.WriteLine("2. Edit last name");
        Console.WriteLine("3. Edit phone number");
        Console.WriteLine("4. Exit");
        string editOption = Console.ReadLine();
        if (!editOptions.Contains(editOption))
        {
            Console.WriteLine("Please enter a valid option :");
            editOption = Console.ReadLine();
        }

        switch (editOption)
        {
            case "1":
                Console.WriteLine("Enter contact first name: ");
                string editFirstName = Console.ReadLine();
                contact.FirstName = editFirstName;
                break;
            case "2":
                Console.WriteLine("Enter contact last name: ");
                string editLastName = Console.ReadLine();
                contact.LastName = editLastName;
                break;
            case "3":
                Console.WriteLine("Enter contact phone number: ");
                string editPhone = Console.ReadLine();
                contact.Phone = editPhone;
                break;
            case "4":
                break;
        }
        contacts.Add(contact);
    }

    private static void DeleteContact(List<Contact> contacts, string search = null)
    {
        if (contacts.Count == 0)
        {
            throw new Exception("There are no contacts");
        }
        
        if (string.IsNullOrEmpty(search))
        {
            throw new Exception("You must enter at least one contact first/last name or full name");
        }
        
        var contact = GetContacts(contacts, search);
        contacts.Remove(contact);
    }

    private static void DisplayContact(Contact contact)
    {
        Console.WriteLine($"First name : {contact.FirstName}");
        Console.WriteLine($"Last name : {contact.LastName}");
        Console.WriteLine($"Phone number : {contact.Phone}");
    }
}