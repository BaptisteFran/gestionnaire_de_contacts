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
                    Console.WriteLine("Enter a search option :");
                    Console.WriteLine("1. Search contact by full name :");
                    Console.WriteLine("2. Search contact by first name :");
                    Console.WriteLine("3. Search contact by last name :");
                    string contactSearchOption = Console.ReadLine();
                    switch (contactSearchOption)
                    {
                        case "1":
                            Console.WriteLine("Enter contact full name: ");
                            string contactFullName = Console.ReadLine();
                            GetContacts(contacts, fullname: contactFullName);
                            break;
                        case "2":
                            Console.WriteLine("Enter contact first name: ");
                            string contactFirstName = Console.ReadLine();
                            GetContacts(contacts, firstName: contactFirstName);
                            break;
                        case "3":
                            Console.WriteLine("Enter contact last name: ");
                            string contactLastName = Console.ReadLine();
                            GetContacts(contacts, lastName: contactLastName);
                            break;
                    }
                    option = "";
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    running = false;
                    break;
            }
        }
    }

    public static bool SetContacts(List<Contact> contacts, string firstName, string lastName, string phone)
    {
        Contact contact = Contact.Create(firstName, lastName, phone);
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

    public static void GetContacts(List<Contact> contacts, string firstName = null, string lastName = null, string fullname = null)
    {
        if (contacts.Count == 0)
        {
            throw new Exception("There are no contacts");
        }
        
        if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(fullname))
        {
            throw new Exception("You must enter at least one contact first/last name or full name");
        }

        if (!string.IsNullOrEmpty(fullname))
        {
            string[] names = fullname.Split(',');
            try
            {
                var contact = contacts.Find(contact =>
                    contact.FirstName == names[0] && contact.LastName == names[1] ||
                    contact.FirstName == names[1] && contact.LastName == names[0]);
                Console.WriteLine("Contact found by full name: ");
                DisplayContact(contact);
            }
            catch (Exception e)
            {
                throw new ArgumentException("There was an error getting the contact : " + e.Message);
            }
        } 
        if (!string.IsNullOrEmpty(lastName))
        {
            try
            {
                var contact = contacts.Find(contact => contact.LastName == lastName);
                Console.WriteLine("Contact found by last name :");
                DisplayContact(contact);
            }
            catch (Exception e)
            {
                throw new ArgumentException("There was an error getting the contact : " + e.Message);
            }
        } 
        if (!string.IsNullOrEmpty(firstName))
        {
            try
            {
                var contact = contacts.Find(contact => contact.FirstName == firstName);
                Console.WriteLine("Contact found by first name :");
                DisplayContact(contact);
            }
            catch (Exception e)
            {
                throw new ArgumentException("There was an error getting the contact : " + e.Message);
            }
        }
    }

    private static void DisplayContact(Contact contact)
    {
        Console.WriteLine($"First name : {contact.FirstName}");
        Console.WriteLine($"Last name : {contact.LastName}");
        Console.WriteLine($"Phone number : {contact.Phone}");
    }
}