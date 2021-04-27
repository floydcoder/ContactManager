// COMP 1202 (46995) ASGMT_2 ( 15% )
// Marco Stevanella
// GBid: 101307949
// Professor Hesam Akbari
// Notes: Hi professor Akbari, I hope you like my program. It has been quite of a challenging assigment for my programming skills, but I have welcomed it as I have really improved my skills with classes and logic.
//  I have included comments that explain the logic I decided to use, I am sure that this can be also helpfull for you when marking it. Thank you very much!

using System;

namespace ASGMT_2
{
    class ContactManagerAPP
    {

        // The creation of an array with a predefined size that will be our "Book".
        // an instance of the class Contact to create the array "contacts" that will serve as a "Book"

        public static byte contactBookSize = 4; // --> made size 4 to help debugging, if desired, it might be changed
        public static Contact[] contacts = new Contact[contactBookSize]; 


        static void Main(string[] args) 
        {
            // MENU 
            char selection;
            
            do
            {
                Instructions();
                selection = Convert.ToChar(Console.ReadLine());

                switch (selection)
                {

                    case '1':
                        AddNewContact();
                        Console.WriteLine("You are out of the create contact option now, press a key to go the the main menu");
                        Console.ReadKey();
                        break;

                    case '2':
                        DisplayContactsList();
                        Console.WriteLine("You are out of the list of contact option now, press a key to go the the main menu");
                        Console.ReadKey();
                        break;
                    case '3':
                        SearchContact();
                        Console.WriteLine("You are out of Search option now, press a key to go the the main menu");
                        Console.ReadKey();
                        break;
                    case '4':
                        DeleteSelectedContact();
                        Console.WriteLine("You are out of Delete option now, press a key to go the the main menu");
                        Console.ReadKey();
                        break;
                    case '5':
                        break;
                    default:
                        Console.WriteLine("The number you entered isn't a valid option");
                        break;

                }
            }
            while (selection != '5');

            Console.WriteLine("GOODBYE");
        }

        public static void Instructions() // a method that displays the instruction to the user.
        {
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            Console.WriteLine("Hello, and welcome to the Contact Manager Service.\n");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n");
            Console.WriteLine("Please, choose any of the following options\n");
            Console.WriteLine("1) For Adding a contact");
            Console.WriteLine("2) View contacts list");
            Console.WriteLine("3) Search Contact");
            Console.WriteLine("4) Delete Contact");
            Console.WriteLine("5) Exit");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n");
        }


        public static void AddNewContact() // --> this method will add a new contact to the array, will also instantiate a new object creation
        {
            try //--> in the week 13 we have seen try & catch, so I tried to use it for this occasion. I am sure it might not have been necessary, but I decided to practice that concept here
            {
                for (byte i = 0; i < contacts.Length; i++)
                {
                    if(contacts[i] == null) //--> if that element of the array is empty... then 
                    {
                        Console.Clear();
                        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
                        Console.WriteLine("                    ADD A CONTACT                 \n");
                        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n");

                        Console.Write("First Name: ");
                        string firstN = Console.ReadLine();

                        Console.Write("Last Name: ");
                        string lastN = Console.ReadLine();

                        Console.Write("Phone Number: ");
                        string phone = Console.ReadLine();

                        Console.Write("Email: ");
                        string email = Console.ReadLine();

                        Console.Write("Day of birth: ");
                        byte day =  Convert.ToByte(Console.ReadLine());

                        Console.Write("Month of birth: ");
                        byte month = Convert.ToByte(Console.ReadLine());

                        Console.Write("Year of birth: ");
                        int year = Convert.ToInt16(Console.ReadLine());

                        // Time for creating a contact object

                        Contact contact = new Contact( // --> INSTANCE
                            firstName: firstN,
                            lastName: lastN,
                            phone: phone,
                            email: email,
                            dayOfBirth: day,
                            monthOfBirth: month,
                            yearOfBirth: year
                            );

                        contacts[i] = contact; // --> new object must be set into the array 
                        Console.WriteLine("CONTACT HAS BEEN SAVED");
                        return;

                    }
                }

                Console.WriteLine("CONTACT BOOK IS FULL");
            }
            catch (Exception e) // --> this catch returns the following if something did not go as I expected
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("SOMETHING WENT WRONG, TRY AGAIN");
            }
        }

        public static void DisplayContactsList() // --> display the book of contacts
        {
            Console.Clear();
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            Console.WriteLine("                    CONTACT BOOK                 \n");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n");

            byte countNullContacts = 0; // --> why byte? because I think that that is the right data type for this project, could be change to int if more data is needed

            for(byte i = 0; i < contacts.Length; i++)
            {
                if (contacts[i] == null)
                {
                    countNullContacts++;
                }
                else if(countNullContacts == contacts.Length)
                {
                    
                }
                else
                {
                    Console.WriteLine($"{contacts[i].GetFullName()}\n");
                }
                
            }
        }

        public static void SearchContact() // --> search contact
        {
            Console.Clear();
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            Console.WriteLine("                    SEARCH CONTACT                \n");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n");

            string[] contactToSearch = GetContact(iWantTo: "search"); // --> creation of a temporary array of string with First and Last name. I have decided to use a helper method "GetContact" to facilitate the operation.

            byte countNullContact = 0; // --> keep a count of null elements
            byte contactNotFound = 0; // --> keep count of the encounted matches

            for( byte i = 0; i < contacts.Length; i++) 
            {
                if (contacts[i] == null)
                {
                    countNullContact++;
                    contactNotFound++;
                }
                else
                {
                    if (contacts[i].LastName.ToUpper() == contactToSearch[1] && contacts[i].FirstName.ToUpper() == contactToSearch[0]) // --> condition that checks the existence of a contact

                    {
                        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
                        Console.WriteLine("                    CONTACT FOUND!                \n");
                        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n");
                        Console.WriteLine(contacts[i].GetInfo());
                        break;
                    }
     
                    else
                    {
                        contactNotFound++; // -->  this element does not have what we searched for
                    }
                }
            }

            if (countNullContact == contacts.Length)  // --> what about if the array is empty?
            {
                Console.WriteLine("Seems like the book is empty...");
            }
            else if (contactNotFound == contacts.Length) // --> we might not have that account throughout the whole array of objects
            {
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
                Console.WriteLine("                    CONTACT NOT FOUND!                \n");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n");
            }
        }

        public static void DeleteSelectedContact() // --> remove contact 
        {
            Console.Clear();
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
            Console.WriteLine("                    DELETE CONTACT                \n");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n");

            string[] contactToDelete = GetContact(iWantTo: "delete");

            byte countNullContact = 0;
            byte contactNotFound = 0;

            for(byte i = 0; i < contacts.Length; i++)
            {
                if (contacts[i] == null)
                {
                    countNullContact++;
                    contactNotFound++;
                }
                else
                {
                    if(contacts[i].LastName.ToUpper() == contactToDelete[1] && contacts[i].FirstName.ToUpper() == contactToDelete[0]) // same sort of logic with search, but this time we have to set the found contact to null
                    {
                        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
                        Console.WriteLine("       WOULD YOU LIKE TO DELETE THIS CONTACT ?    \n");
                        Console.WriteLine(contacts[i].GetFullName());
                        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=");
                        Console.WriteLine("Digit 'y' for YES, 'n' for NO\n\n");
                        char confirm = Convert.ToChar(Console.ReadLine());

                        switch (confirm)
                        {
                            case 'y':
                                contacts[i] = null;
                                Console.WriteLine($"CONTACT DELETED");
                                break;
                            case 'n':
                                Console.WriteLine($"CONTACT HAS NOT BEEN DELETED");
                                break;
                            default:
                                Console.WriteLine("You have entered a wrong digit, remember...");
                                Console.WriteLine("Digit 'y' for YES, 'n' for NO\n\n");
                                break;

                        }
                    }
                    else
                    {
                        contactNotFound++;
                    }
                }
            }

            if (countNullContact == contacts.Length)
            {
                Console.WriteLine("Seems like the book is empty...");
            }
            else if (contactNotFound == contacts.Length)
            {
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");
                Console.WriteLine("                    CONTACT NOT FOUND!                \n");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n\n");
            }

        }

        public static string [] GetContact(string iWantTo) // --> I have been thinking how do I manage to get the contact that the user wants to target?
                                                            // then I figured that it would have been beter if I would use a helper method that would return me
                                                            // the name and last name of the contact in an array form. 
        {
           var contactName = new string [2];
            Console.WriteLine($"Press enter to {iWantTo} the selected contact");
            Console.WriteLine($"First name: ");
            string firstN = Console.ReadLine().ToUpper();
            contactName[0] = firstN;

            Console.WriteLine($"First name: ");
            string lastN = Console.ReadLine().ToUpper();
            contactName[1] = lastN;

            return contactName;
        }

    }
}
